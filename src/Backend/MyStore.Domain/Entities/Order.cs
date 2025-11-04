using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities
{
    public class Order: EntityBase
    {
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public IList<OrderItem> OrderItems { get; set; } = [];
    }
}
