using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Communication.Response
{
    public class ResponseCustomersJson
    {
        public IList<ResponseShortCustomerJson> Customers { get; set; } = [];
    }
}
