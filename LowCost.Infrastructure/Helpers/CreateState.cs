using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Helpers
{
    public class CreateState
    {
        public bool CreatedSuccessfully { get; set; }
        public int Id { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
