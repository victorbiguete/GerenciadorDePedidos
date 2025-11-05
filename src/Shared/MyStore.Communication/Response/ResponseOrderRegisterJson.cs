using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Communication.Response
{
    public class ResponseOrderRegisterJson
    {
        public long OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
