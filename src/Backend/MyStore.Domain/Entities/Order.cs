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
        [BsonRepresentation(BsonType.Int64)]
        public long CustomerId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}
