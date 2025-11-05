using MyStore.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Communication.Response
{
    public class ResponseOrderUpdateStatusJson
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
