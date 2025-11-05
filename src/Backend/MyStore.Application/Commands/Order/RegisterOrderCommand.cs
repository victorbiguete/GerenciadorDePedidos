using MediatR;
using MyStore.Application.Commands.OrderItens;
using MyStore.Communication.Response;
using MyStore.Domain.Entities;
using MyStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order
{
    public class RegisterOrderCommand : IRequest<ResponseOrderRegisterJson>
    {
        public long CustomerId { get; set; }
        [JsonIgnore]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public IList<RegisterOrderItemCommand> Items { get; set; } = [];
    }
}
