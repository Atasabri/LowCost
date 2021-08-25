using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Generic
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        /// <summary>
        /// Create Function For Create Entity Asynchronous
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(Entity entity);
        /// <summary>
        /// Update Function If Entity Excist => Update , If Not => Create
        /// </summary>
        /// <param name="entity"></param>
        void Update(Entity entity);
        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Entity entity);
        /// <summary>
        /// Find Item By ID Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Entity> FindByIdAsync(int Id);
        /// <summary>
        /// Get Single Item Using Expression Asynchronous
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<Entity> FindElementAsync(Expression<Func<Entity, bool>> expression, string includes = null);
        /// <summary>
        /// Get More Items Using Expression Asynchronous
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IEnumerable<Entity>> GetElementsAsync(Expression<Func<Entity, bool>> expression, string includes = null);
        /// <summary>
        /// Get More Items Using Expression With Pagination Asynchronous
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pagingParameters"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<PagedResult<Entity>> GetElementsAsync(Expression<Func<Entity, bool>> expression, PagingParameters pagingParameters, string includes = null);
        /// <summary>
        /// Get More Items Using Expression With Pagination And Ordering Asynchronous
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pagingParameters"></param>
        /// <param name="includes"></param>
        /// <param name="orderExpression"></param>
        /// <param name="orderingType"></param>
        /// <returns></returns>
        Task<PagedResult<Entity>> GetElementsWithOrderAsync(Expression<Func<Entity, bool>> expression
            , PagingParameters pagingParameters
            , Expression<Func<Entity, object>> orderExpression
            , OrderingType orderingType = OrderingType.Ascending
            , string includes = null);
    }
}
