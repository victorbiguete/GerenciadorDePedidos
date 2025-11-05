using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusCommands : IRequest
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
