using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Pagination
{
    public class PagingParameters
    {
        public PagingParameters()
        {
                
        }
        public PagingParameters(int index, int size)
        {
            this.Index = index;
            this.Size = size;
        }
        public int Index { get; set; }

        private int _size = Constants.MaxPageSize;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value == 0 ? _size : value;
            }
        }
    }
}
