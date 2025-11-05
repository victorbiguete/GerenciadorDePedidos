using AutoMapper;
using MediatR;
using MyStore.Application.Queries.Customer.GetAllAsync;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository.ICustomer;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Customer.GetByIdAsync
{
    public class GetByIdAsyncHandler:IRequestHandler<GetByIdAsyncQuerie, ResponseShortCustomerJson>
    {
        private readonly ICustomerReadRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdAsyncHandler(ICustomerReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseShortCustomerJson> Handle(GetByIdAsyncQuerie request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer is null)
                throw new NotFoundException(ResourceMessagesExceptions.CUSTOMERS_NOT_FOUND);

            return _mapper.Map<ResponseShortCustomerJson>(customer);
        }
    }
}
