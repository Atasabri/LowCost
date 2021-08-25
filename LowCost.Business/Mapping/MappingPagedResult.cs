using AutoMapper;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public static class MappingPagedResult
    {
        /// <summary>
        /// Convert PagedResult Object TO Mapped PagedResult Object
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="pagedResult"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static PagedResult<TDestination> ToMappedPagedResult<TSource, TDestination>(this PagedResult<TSource> pagedResult, IMapper mapper, Action<IMappingOperationOptions<IEnumerable<TSource>, IEnumerable<TDestination>>> opts = null) where TSource : class where TDestination : class
        {
            IEnumerable<TDestination> mappedItems = 
                opts == null ? mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(pagedResult.Items) :
                 mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(pagedResult.Items, opts);
            
            var mappedPagedResult =  new PagedResult<TDestination>()
            {
                PageNumber = pagedResult.PageNumber,
                Size = pagedResult.Size,
                AllCount = pagedResult.AllCount,
                Items = mappedItems,
            };

            return mappedPagedResult;
        }
    }
}
