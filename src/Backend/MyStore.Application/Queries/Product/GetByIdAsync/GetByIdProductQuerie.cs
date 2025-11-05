using MediatR;
using MyStore.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Product.GetByIdAsync
{
    public class GetByIdProductQuerie : IRequest<ResponseShortProductJson>
    {
        public long Id { get; set; }
    }
}
