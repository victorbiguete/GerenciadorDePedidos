using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Migration
{
    public abstract record DatabaseVersions
    {
        public const int TABLE_CUSTOMER = 1;
        public const int TABLE_PRODUCT = 2;
        public const int TABLE_ORDER = 3;
        public const int TABLE_ORDER_ITEM = 4;
    }
}
