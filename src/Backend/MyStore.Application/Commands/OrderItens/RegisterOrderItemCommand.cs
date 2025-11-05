using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.OrderItens
{
    public class RegisterOrderItemCommand
    {
        [JsonIgnore]
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        [JsonIgnore]
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [JsonIgnore]
        public decimal UnitPrice { get; set; }
        [JsonIgnore]
        public decimal TotalPrice { get; set; }
    }
}
