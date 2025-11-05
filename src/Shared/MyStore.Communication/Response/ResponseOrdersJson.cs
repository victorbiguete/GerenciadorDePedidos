using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Communication.Response
{
    public class ResponseOrdersJson
    {
        public IList<ResponseOrderJson> Orders { get; set; } = [];
    }
}
