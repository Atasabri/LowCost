using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Implementation.Orders
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(DB context)
            : base(context)
        {
        }

        public async Task<double> GetOrdersTotalSumAsync(Expression<Func<Order, bool>> expression)
        {
           return await _entities.Where(expression).SumAsync(order => order.Total);
        }
    }
}
