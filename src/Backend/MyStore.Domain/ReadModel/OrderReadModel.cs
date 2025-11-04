using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyStore.Domain.Entities;
using MyStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.ReadModel
{
    public class OrderReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }
        public long Id { get; set; }
        public bool Active { get; set; } 
        public DateTime CreatedOn { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }

        public IList<OrderItemReadModel> OrderItems { get; set; } = [];
    }
}
