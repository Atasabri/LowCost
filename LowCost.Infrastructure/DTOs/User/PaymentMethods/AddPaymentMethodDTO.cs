using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.User.PaymentMethods
{
    public class AddPaymentMethodDTO
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpDate { get; set; }
        public string CVV { get; set; }
        [JsonIgnore]
        public string User_Id { get; set; }
    }
}
