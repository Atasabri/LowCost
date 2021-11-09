using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Interfaces.Orders
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        /// <summary>
        /// Get Sum Of Orders Total Price Asynchronous
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<double> GetOrdersTotalSumAsync(Expression<Func<Order, bool>> expression);
    }
}
