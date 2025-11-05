using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Communication.Response
{
    public class ResponseProductsJson
    {
        public IList<ResponseShortProductJson> Products { get; set; } = [];
    }
}
