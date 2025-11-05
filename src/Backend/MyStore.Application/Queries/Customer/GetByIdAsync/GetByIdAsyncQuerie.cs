using MediatR;
using MyStore.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Customer.GetByIdAsync
{
    public class GetByIdAsyncQuerie : IRequest<ResponseShortCustomerJson>
    {
        public long Id { get; set; }
    }
}
