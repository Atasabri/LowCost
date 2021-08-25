using LowCost.Domain.Models;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Interfaces.Products
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsRecommendedAsync(PagingParameters pagingParameters);
        Task<IEnumerable<Product>> GetProductsWithFiltrationAsync(PagingParameters pagingParameters);
    }
}
