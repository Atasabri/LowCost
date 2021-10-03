using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.Wallet
{
    public class AddTransactionDTO
    {
        [JsonIgnore]
        public DateTime Date { get; set; } = DateTimeProvider.GetEgyptDateTime();
        public double Money { get; set; }
        public string Comment { get; set; }
    }
}
