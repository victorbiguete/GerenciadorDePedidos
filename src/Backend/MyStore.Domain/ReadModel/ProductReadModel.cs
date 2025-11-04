using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.ReadModel
{
    public class ProductReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }
        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
