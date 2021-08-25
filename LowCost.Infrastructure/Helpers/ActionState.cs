using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Helpers
{
    public class ActionState
    {
        public bool ExcuteSuccessfully { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
