using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
    }
}
