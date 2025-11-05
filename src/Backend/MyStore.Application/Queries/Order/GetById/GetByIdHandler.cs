using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository.Order;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Order.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuerie, ResponseOrderJson>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdHandler(IOrderReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseOrderJson> Handle(GetByIdQuerie request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);

            if (result is null)
                throw new NotFoundException(ResourceMessagesExceptions.ORDER_NOT_FOUND);

            return _mapper.Map<ResponseOrderJson>(result);
        }
    }
}
