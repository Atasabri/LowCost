using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Error_Handling
{
    public class ExceptionResponse
    {
        public string Error { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerMessage { get; set; }
    }
}
