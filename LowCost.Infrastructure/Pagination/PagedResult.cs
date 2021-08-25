using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowCost.Infrastructure.Pagination
{
    public class PagedResult<Entity> where Entity : class
    {
        public PagedResult()
        {
                
        }
        public PagedResult(int index, int Size, int allCount, IEnumerable<Entity> items)
        {
            this.PageNumber = index + 1;
            this.Size = Size;
            this.AllCount = allCount;
            this.Items = items;
        }
        public int PageNumber { get; set; }
        public int Size { get; set; }
        public int PagesCount
        {
            get
            {
                return (int)Math.Ceiling(AllCount / (double)Size);
            }
        }
        public int PageSize
        {
            get
            {
                return this.Items.Count();
            }
        }
        public int AllCount { get; set; }
        public IEnumerable<Entity> Items { get; set; }
    }
}
