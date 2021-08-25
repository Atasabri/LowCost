using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Implementation.Products
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(DB context)
            : base(context)
        {
        }

        public Task<IEnumerable<Product>> GetProductsRecommendedAsync(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsWithFiltrationAsync(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }
    }
}
