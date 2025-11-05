using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository.ICustomer;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Customer.GetAllAsync
{
    public class GetAllAsyncHandler:IRequestHandler<GetAllAsyncQuery,ResponseCustomersJson>
    {
        private readonly ICustomerReadRepository _repository;

        private readonly IMapper _mapper;

        public GetAllAsyncHandler(ICustomerReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseCustomersJson> Handle(GetAllAsyncQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetAllAsync();

            return new ResponseCustomersJson
            {
                Customers = _mapper.Map<List<ResponseShortCustomerJson>>(customer)
            };
        }
    }
}
