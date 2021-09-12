using LowCost.Domain.Context;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.OrderSizeDelivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.OrderSizeDelivery
{
    public class OrderSizeDeliveryRepository : GenericRepository<Domain.Models.OrderSizeDelivery>, IOrderSizeDeliveryRepository
    {
        public OrderSizeDeliveryRepository(DB context)
    : base(context)
        {
        }
    }
}
