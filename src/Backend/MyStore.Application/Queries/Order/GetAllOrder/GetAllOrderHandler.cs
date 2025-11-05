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

namespace MyStore.Application.Queries.Order.GetAllOrder
{
    public class GetAllOrderHandler: IRequestHandler<GetAllOrderQuerie,ResponseOrdersJson>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrderHandler(IOrderReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseOrdersJson> Handle(GetAllOrderQuerie request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();

            if (result is null)
                throw new NotFoundException(ResourceMessagesExceptions.ORDER_EMPTY);

            return new ResponseOrdersJson()
            {
                Orders = _mapper.Map<IList<ResponseOrderJson>>(result)
            };
        }
    }
}
