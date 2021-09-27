using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Orders.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Orders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using LowCost;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LowCost.Resources;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Business.Helpers;
using LowCost.Business.Helpers.NotificationHelpers;

namespace LowCost.Business.Services.Orders.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OrderNotificationHandler _orderNotificationHandler;
        private readonly WebNotificationHandler _webNotificationHandler;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public OrdersService(IUnitOfWork unitOfWork, OrderNotificationHandler orderNotificationHandler,
            WebNotificationHandler webNotificationHandler,
            IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._orderNotificationHandler = orderNotificationHandler;
            this._webNotificationHandler = webNotificationHandler;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<CreateState> AddOrderAsync(AddOrderDTO addOrderDTO)
        {
            var createState = new CreateState();
            var generateOrderResult = await GenerateOrderAsync(addOrderDTO);

            if(!generateOrderResult.OrderGeneratedSuccessfully)
            {
                createState.ErrorMessages = generateOrderResult.ErrorMessages;
                return createState;
            }

            Order order = generateOrderResult.Order;

            await _unitOfWork.OrdersRepository.CreateAsync(order);

            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                createState.CreatedSuccessfully = true;
                // Sending Notification To Admin Control Panel
                var orderViewModel = _mapper.Map<Order, ListingOrderViewModel>(order);
                var webNotificationState = new WebNotificationState("AddOrder", orderViewModel);
                webNotificationState.Groups = new string[] { order.Stock_Id.ToString(), Constants.AccessAllDashboardStocksDataGroupName };
                await _webNotificationHandler.WebNotifyDashboardGroupsAsync(webNotificationState);
                createState.Id = order.Id;
            }
            else
            {
                createState.ErrorMessages.Add(_stringLocalizer["Can Not Create This Order !"]);
            }

            return createState;
        }

        public async Task<PromoCodeDTO> CheckPromoCodeAsync(string promoCode)
        {
            var promoCodeDTO = new PromoCodeDTO();
            if(!string.IsNullOrEmpty(promoCode))
            {
                var promoCodeItem = await _unitOfWork.PromoCodesRepository.FindElementAsync(promo =>
                     promo.Code == promoCode);
                if(promoCodeItem != null)
                {
                    promoCodeDTO.PromoCodeFound = true;
                    promoCodeDTO.DiscountPercent = promoCodeItem.DiscountPercent;
                    promoCodeDTO.Category_Id = promoCodeItem.Category_Id;
                    promoCodeDTO.SubCategory_Id = promoCodeItem.SubCategory_Id;
                    promoCodeDTO.Zone_Id = promoCodeItem.Zone_Id;
                    promoCodeDTO.FreeDelivery = promoCodeItem.FreeDelivery;
                }
            }
            return promoCodeDTO;
        }

        private async Task CalculateOrderDeliveryAsync(Order order, PromoCodeDTO promoCode)
        {
            if(promoCode != null && promoCode.FreeDelivery)
            {
                order.Delivery = 0;
            }
            else
            {
                order.TotalSize = order.OrderDetails.Sum(orderDetails => orderDetails.Size);
                order.Delivery = await GetDeliveryBySizeAsync(order.TotalSize);
            }      
        }

        private async Task CheckOrderHasNoDeliveryAndCalculateOrderFinalTotalPriceAsync(Order order)
        {
            double priceWithNoDeliveryValue = await GetPriceWithNoDeliveryAsync();
            double totalWithoutDelivery = order.SubTotal - order.Discount;
            if (totalWithoutDelivery >= priceWithNoDeliveryValue)
            {
                order.Delivery = 0;
            }
            order.Total = totalWithoutDelivery + order.Delivery;
        }

        private async Task<ActionState> AddingOrderZoneAndStockAsync(Order order, int zoneId)
        {
            var actionState = new ActionState();
            var zone = await _unitOfWork.ZonesRepository.FindByIdAsync(zoneId);
            if (zone != null)
            {
                order.Zone_Id = zone.Id;
                order.Stock_Id = zone.Stock_Id;

                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Found Zone !"]);
            return actionState;
        }

        private async Task<PromoCodeDTO> GetOrderPromoCodeAsync(int orderZoneId, string promoCode)
        {
            var promoResult = await CheckPromoCodeAsync(promoCode);
            if (promoResult.PromoCodeFound)
            {
                if (!promoResult.Zone_Id.HasValue || (promoResult.Zone_Id.HasValue && promoResult.Zone_Id.Value == orderZoneId))
                {
                    return promoResult;
                }
                //order.Discount = (promoResult.DiscountPercent / 100) * order.SubTotal;
            }
            return null;
        }

        private async Task<ActionState> CheckOrderWithZeroCostItemsTotalLimitationAsync(double orderTotal)
        {
            var actionState = new ActionState();
            double maxLimit;
            bool hasMaxLimitForZeroWithCost = double.TryParse(await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.LimitPriceForUseZeroWithCost), out maxLimit);
            double maxLimitForZeroWithCost = hasMaxLimitForZeroWithCost ? maxLimit : Constants.DefaultLimitPriceForUseZeroWithCost;
            if (orderTotal >= maxLimitForZeroWithCost)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["To Order Zero With Cost Items You Must Order More Than {0} LE", maxLimitForZeroWithCost]);
            return actionState;
        }

        private async Task<ActionState> AssignOrderDetailsAsync(Order order, PromoCodeDTO promoCode)
        {
            var actionState = new ActionState();

            int productsWithZeroCostCount = 0;
            foreach (var orderDetailsItem in order.OrderDetails)
            {
                // Check If Quantity More Than 0
                if (orderDetailsItem.Quantity <= 0)
                {
                    actionState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                    actionState.ErrorMessages.Add(orderDetailsItem.Market_Id.ToString());
                    actionState.ErrorMessages
                        .Add(_stringLocalizer["Please Add Quantity For Product '{0}' In Market '{1}'",
                        orderDetailsItem.Product_Id, orderDetailsItem.Market_Id]);
                    return actionState;

                }

                // Get Price and Adding To Order Details & Order Subtotal
                var priceItem = await _unitOfWork.PricesRepository.FindElementAsync(price =>
                            price.Product_Id == orderDetailsItem.Product_Id &&
                            price.Market_Id == orderDetailsItem.Market_Id, string.Format("{0}.{1}", nameof(Product), nameof(Product.SubCategory)));
                if (priceItem == null)
                {
                    actionState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                    actionState.ErrorMessages.Add(orderDetailsItem.Market_Id.ToString());
                    actionState.ErrorMessages
                        .Add(_stringLocalizer["There Is No Price With Product Id '{0}' and Market Id '{1}'",
                        orderDetailsItem.Product_Id, orderDetailsItem.Market_Id]);
                    return actionState;
                }
                if(orderDetailsItem.Quantity > priceItem.MaxQuantityPerOrder)
                {
                    actionState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                    actionState.ErrorMessages.Add(orderDetailsItem.Market_Id.ToString());
                    actionState.ErrorMessages
                        .Add(_stringLocalizer["You Can Order Just {0} from This Offer in Product Id '{1}' and Market Id '{2}'",
                        priceItem.MaxQuantityPerOrder, orderDetailsItem.Product_Id, orderDetailsItem.Market_Id]);
                    return actionState;
                }
                if (priceItem.Price == 0)
                {
                    productsWithZeroCostCount++;
                }
                // Check If User Adding Products With Zero Cost More Than The Max Default Value in One Product
                if (productsWithZeroCostCount > Constants.MaxZeroItemsinOrder)
                {
                    actionState.ErrorMessages.Add(_stringLocalizer["You Can Order Only One Product With Zero Cost"]);
                    return actionState;
                }
                orderDetailsItem.Price = priceItem.Price;
                orderDetailsItem.Size = priceItem.Product.Size * orderDetailsItem.Quantity;

                double orderDetailsTotal = orderDetailsItem.Price * orderDetailsItem.Quantity;
                if (promoCode != null)
                {
                    if ((!promoCode.Category_Id.HasValue && !promoCode.SubCategory_Id.HasValue)
                            || (!promoCode.SubCategory_Id.HasValue && promoCode.Category_Id.HasValue && promoCode.Category_Id.Value == priceItem.Product.SubCategory.Category_Id)
                            || (promoCode.SubCategory_Id.HasValue && promoCode.SubCategory_Id.Value == priceItem.Product.SubCategory_Id))
                    {
                        order.Discount += (promoCode.DiscountPercent / 100) * orderDetailsTotal;
                    }
                }
                order.SubTotal += orderDetailsTotal;

                // Decrease Quantity Of Product
                var productQuantityStock = await _unitOfWork.StockProductsRepository
                    .FindElementAsync(stockQuantity =>
                    stockQuantity.Product_Id == orderDetailsItem.Product_Id && stockQuantity.Stock_Id == order.Stock_Id);
                // Check If Quantity Not Available
                if (productQuantityStock == null || orderDetailsItem.Quantity > productQuantityStock.Quantity)
                {
                    actionState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                    actionState.ErrorMessages.Add(_stringLocalizer["Quantity Of Product '{0}' Not Available In Stock", orderDetailsItem.Product_Id]);
                    return actionState;
                }
                productQuantityStock.Quantity -= orderDetailsItem.Quantity;
                _unitOfWork.StockProductsRepository.Update(productQuantityStock);
            }
            // Check If User Order Zero With Cost And Price Limitation More Than Default
            if (productsWithZeroCostCount > 0)
            {
                var orderWithZeroCostItemsTotalLimitationResult = await CheckOrderWithZeroCostItemsTotalLimitationAsync(order.SubTotal);
                if (!orderWithZeroCostItemsTotalLimitationResult.ExcuteSuccessfully)
                {
                    actionState.ErrorMessages = orderWithZeroCostItemsTotalLimitationResult.ErrorMessages;
                    return actionState;
                }
            }
            actionState.ExcuteSuccessfully = true;
            return actionState;
        }

        public async Task<GenerateOrderState> GenerateOrderAsync(AddOrderDTO addOrderDTO)
        {
            var generateOrderState = new GenerateOrderState();
            // Get Current User Id
            var currentUser = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            addOrderDTO.User_Id = currentUser.Id;

            var order = _mapper.Map<AddOrderDTO, Order>(addOrderDTO);
            // Check And Add Zone & Stock to Order
            int? zoneId = addOrderDTO.Zone_Id.HasValue ? addOrderDTO.Zone_Id : currentUser.Zone_Id;
            var addingOrderZoneStockResult = await AddingOrderZoneAndStockAsync(order, zoneId.Value);
            if (!addingOrderZoneStockResult.ExcuteSuccessfully)
            {
                generateOrderState.ErrorMessages = addingOrderZoneStockResult.ErrorMessages;
                return generateOrderState;
            }
            // Check Promo Code Found And Promo Code Zone Equal Order Zone
            PromoCodeDTO promoCode = null;
            if (!string.IsNullOrEmpty(addOrderDTO.PromoCode))
            {
                var promoResult = await GetOrderPromoCodeAsync(order.Zone_Id, addOrderDTO.PromoCode);
                if (promoResult != null)
                {
                    promoCode = promoResult;
                }
                else
                {
                    generateOrderState.ErrorMessages.Add(_stringLocalizer["Can Not Found This Promo Code !"]);
                    return generateOrderState;
                }
            }

            if (order.OrderDetails.Any())
            {
                var assignOrderDetailsResult = await AssignOrderDetailsAsync(order, promoCode);
                if (!assignOrderDetailsResult.ExcuteSuccessfully)
                {
                    generateOrderState.ErrorMessages = assignOrderDetailsResult.ErrorMessages;
                    return generateOrderState;
                }
            }
            else
            {
                generateOrderState.ErrorMessages.Add(_stringLocalizer["Your Cart Is Empty , Please Add Products"]);
                return generateOrderState;
            }

            if (order.SubTotal == 0)
            {
                generateOrderState.ErrorMessages.Add(_stringLocalizer["You Can Not Order Product With Zero Price Only !"]);
                return generateOrderState;
            }

            // Get Order Delivery Depend on Order Size
            await CalculateOrderDeliveryAsync(order, promoCode);

            // Calculate Final Order Total Price & Check if Order has No Delivery
            await CheckOrderHasNoDeliveryAndCalculateOrderFinalTotalPriceAsync(order);

            generateOrderState.OrderGeneratedSuccessfully = true;
            generateOrderState.Order = order;
            return generateOrderState;
        }



        public async Task<PagedResult<ListingOrderDTO>> GetDriverOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Driver_Id == driverId && !order.Finished && !order.Closed,
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<PagedResult<ListingOrderDTO>> GetDriverFinishedOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Driver_Id == driverId && (order.Finished || order.Closed),
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(int orderId)
        {            
            // Get Current User Id
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Get Order
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId &&
                              order.User_Id == userId,
                              string.Format("{0}.{1},{2}.{3},{2}.{4},{5}"
                              , nameof(Order.OrderStatuses)
                              , nameof(OrderStatus.Status)
                              , nameof(Order.OrderDetails)
                              , nameof(OrderDetails.Product)
                              , nameof(OrderDetails.Market)
                              , nameof(Order.Driver)));

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }

        public async Task<OrderDTO> GetDriverOrderDetailsAsync(int orderId)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Get Order
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId &&
                              order.Driver_Id == driverId,
                              string.Format("{0}.{1},{2}.{3},{2}.{4},{5},{6}"
                              , nameof(Order.OrderStatuses)
                              , nameof(OrderStatus.Status)
                              , nameof(Order.OrderDetails)
                              , nameof(OrderDetails.Product)
                              , nameof(OrderDetails.Market)
                              , nameof(Order.User)
                              , nameof(Order.Driver)));

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }

        public async Task<PagedResult<ListingOrderDTO>> GetOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current User Id
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.User_Id == userId,
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<double> CalculateUserSavedMoneyAsync(List<AddOrderDetailsDTO> productsDetails)
        {
            double savedMoney = 0;
            foreach (var item in productsDetails)
            {
                var prices = await _unitOfWork.PricesRepository.GetElementsAsync(price => price.Product_Id == item.Product_Id);

                double itemSavedMoney = prices.Max(price => price.Price) - prices.FirstOrDefault(price => price.Market_Id == item.Market_Id).Price;
                savedMoney += item.Quantity * itemSavedMoney;
            }

            return savedMoney;
        }

        public async Task<ActionState> StartOrderAsync(int orderId)
        {
            var actionState = new ActionState();
            string currentDriverId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId && order.Driver_Id == currentDriverId);
            if (order == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
                return actionState;
            }
            order.Started = true;
            order.Start_Date = DateTimeProvider.GetEgyptDateTime();
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                await _orderNotificationHandler.NotifyUserOrderAsync(orderId, "Your order '{0}' has been delivered");
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
            return actionState;
        }

        public async Task<ActionState> FinishOrderAsync(int orderId)
        {
            var actionState = new ActionState();
            string currentDriverId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId && order.Driver_Id == currentDriverId);
            if (order == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
                return actionState;
            }
            order.Finished = true;
            order.Finish_Date = DateTimeProvider.GetEgyptDateTime();
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                await _orderNotificationHandler.NotifyUserOrderAsync(orderId, "Your Order '{0}' has been completed");
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Finish Order"]);
            return actionState;
        }

        public async Task<ActionState> CloseOrderAsync(int orderId)
        {
            var actionState = new ActionState();
            string currentUserId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId && order.User_Id == currentUserId);
            if (order == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Close Order"]);
                return actionState;
            }
            if(order.Driver_Id != null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Order Assign to Driver , please Call Driver to Stop Order"]);
                return actionState;
            }
            order.Closed = true;
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Close Order"]);
            return actionState;
        }

        public async Task<double> GetOrderDeliveryAsync(List<AddOrderDetailsDTO> orderDetails)
        {
            double totalPrice = 0;
            List<int> products = new List<int>();
            foreach (var orderDetail in orderDetails)
            {
                var price = await _unitOfWork.PricesRepository.FindElementAsync(price =>
                price.Product_Id == orderDetail.Product_Id && price.Market_Id == orderDetail.Market_Id);

                if(price != null)
                {
                    totalPrice += price.Price * orderDetail.Quantity;
                }
                else
                {
                    throw new Exception(string.Format("There is No Item With Product Id {0} and Market Id {1}", orderDetail.Product_Id, orderDetail.Market_Id));
                }
                products.Add(orderDetail.Product_Id);
            }
            double priceWithNoDeliveryValue = await GetPriceWithNoDeliveryAsync();

            if(totalPrice >= priceWithNoDeliveryValue)
            {
                return 0;
            }
            var productsTotalSize = await _unitOfWork.ProductsRepository.GetProductsSizeAsync(products.ToArray());
            return await GetDeliveryBySizeAsync(productsTotalSize);
        }

        private async Task<double> GetDeliveryBySizeAsync(double size)
        {
            // Get Delivery Value From DataBase and Assign to Order
            var orderSizeDelivery = await _unitOfWork.OrderSizeDeliveryRepository.FindElementAsync(orderSizeDelivery =>
            size >= orderSizeDelivery.SizeFrom && size <= orderSizeDelivery.SizeTo);
            if (orderSizeDelivery != null)
            {
                return orderSizeDelivery.Delivery;
            }
            else
            {
                // Return Default Delivery 
                double delivery;
                bool hasDelivery = double.TryParse(await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.DeliveryKey), out delivery);
                return hasDelivery ? delivery : Constants.DefaultDeliveryValue;
            }
        }

        private async Task<double> GetPriceWithNoDeliveryAsync()
        {
            double priceWithNoDelivery;
            bool hasPriceWithNoDelivery = double.TryParse(await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.PriceWithNoDeliveryKey), out priceWithNoDelivery);
            double priceWithNoDeliveryValue = hasPriceWithNoDelivery ? priceWithNoDelivery : Constants.DefaultPriceWithNoDelivery;

            return priceWithNoDeliveryValue;
        }

    }
}
