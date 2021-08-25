using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User.PaymentMethods
{
    public class PaymentMethodDTO : BaseDTO
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpDate { get; set; }
        public string CVV { get; set; }
    }
}
