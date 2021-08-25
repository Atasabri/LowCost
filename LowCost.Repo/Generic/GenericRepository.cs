using LowCost.Domain.Context;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Generic
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected DB _context { get; set; }
        protected readonly DbSet<Entity> _entities;

        public GenericRepository(DB context)
        {
            _context = context;
            _entities = _context.Set<Entity>();
        }

        public virtual async Task CreateAsync(Entity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual void Update(Entity entity)
        {
            _entities.Update(entity);
        }

        public virtual void Delete(Entity entity)
        {
            _entities.Remove(entity);
        }
        public async Task<Entity> FindByIdAsync(int Id)
        {
            return await _entities.FindAsync(Id);
        }

        public async Task<Entity> FindElementAsync(Expression<Func<Entity, bool>> expression, string includes = null)
        {
            var Element = await _entities.Where(expression).MultiInclude(includes).FirstOrDefaultAsync();
            return Element;
        }

        public async Task<IEnumerable<Entity>> GetElementsAsync(Expression<Func<Entity, bool>> expression, string includes = null)
        {
            var entities = await _entities.Where(expression).MultiInclude(includes).ToListAsync();
            return entities;
        }

        public async Task<PagedResult<Entity>> GetElementsAsync(Expression<Func<Entity, bool>> expression, PagingParameters pagingParameters, string includes = null)
        {
            int skip = pagingParameters.Index * pagingParameters.Size;

            var entities = await _entities.Where(expression).Skip(skip)
                .Take(pagingParameters.Size).MultiInclude(includes).ToListAsync();

            return new PagedResult<Entity>(pagingParameters.Index, pagingParameters.Size, await GetCount(expression), entities);
        }

        public async Task<PagedResult<Entity>> GetElementsWithOrderAsync(Expression<Func<Entity, bool>> expression
            , PagingParameters pagingParameters
            , Expression<Func<Entity, object>> orderExpression
            , OrderingType orderingType = OrderingType.Ascending
            , string includes = null)
        {
            int skip = pagingParameters.Index * pagingParameters.Size;

            var entities = await _entities.Where(expression).Order(orderExpression, orderingType).Skip(skip)
                .Take(pagingParameters.Size).MultiInclude(includes).ToListAsync();

            return new PagedResult<Entity>(pagingParameters.Index, pagingParameters.Size, await GetCount(expression), entities);
        }

        private async Task<int> GetCount(Expression<Func<Entity, bool>> expression)
        {
            return await _entities.Where(expression).CountAsync();
        }
    }

    public static class Include
    {
        /// <summary>
        /// Extention Method For Create Multi Include For Entities
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public static IQueryable<Entity> MultiInclude<Entity>(this IQueryable<Entity> query, string includes = null) where Entity : class
        {
            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (var item in includes.Split(','))
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }

    public static class Ordering
    {
        /// <summary>
        /// Extention Method For Order Entities
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="query"></param>
        /// <param name="expression"></param>
        /// <param name="orderingType"></param>
        /// <returns></returns>
        public static IQueryable<Entity> Order<Entity>(this IQueryable<Entity> query, Expression<Func<Entity, object>> expression,
            OrderingType orderingType = OrderingType.Ascending) where Entity : class
        {
            switch (orderingType)
            {
                 case OrderingType.Ascending:
                      query = query.OrderBy(expression);
                      break;
                 case OrderingType.Descending:
                      query = query.OrderByDescending(expression);
                      break;
            }
            return query;
        }
    }
}
