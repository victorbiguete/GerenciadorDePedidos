using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommands : IRequest
    {
        public long Id { get; set; }
    }
}
