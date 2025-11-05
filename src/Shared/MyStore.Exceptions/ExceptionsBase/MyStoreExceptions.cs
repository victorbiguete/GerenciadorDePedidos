using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Exceptions.ExceptionsBase
{
    public class MyStoreExceptions : Exception
    {
        public MyStoreExceptions(string? message) : base(message)
        {
        }
    }
}
