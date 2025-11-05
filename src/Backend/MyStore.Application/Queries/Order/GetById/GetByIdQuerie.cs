using MediatR;
using MyStore.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Order.GetById
{
    public class GetByIdQuerie : IRequest<ResponseOrderJson>
    {
        public long Id { get; set; }
    }
}
