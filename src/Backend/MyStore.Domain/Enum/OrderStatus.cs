using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Enum
{
    public enum OrderStatus
    {
        Draft = 0,
        Created = 1,
        Confirmed = 2,
        Shipped = 3,
        Cancelled = 4
    }
}
