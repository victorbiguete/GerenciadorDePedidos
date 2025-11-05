using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : MyStoreExceptions
    {
        public IList<string> ErrorsMessages { get; set; }
        public ErrorOnValidationException(IList<string> errors) : base(string.Empty)
        {
            ErrorsMessages = errors;
        }
    }
}
