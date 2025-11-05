using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository.ICustomer;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Customer.GetAllAsync
{
    public record GetAllAsyncQuery : IRequest<ResponseCustomersJson>
    {
        
    }
}
