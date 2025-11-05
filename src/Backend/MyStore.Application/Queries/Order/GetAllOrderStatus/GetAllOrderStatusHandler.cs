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

namespace MyStore.Application.Queries.Order.GetAllOrderStatus
{
    public class GetAllOrderStatusHandler : IRequestHandler<GetAllOrderStatusQuerie, ResponseOrdersJson>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrderStatusHandler(IOrderReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseOrdersJson> Handle(GetAllOrderStatusQuerie request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllOrderStatus(request.Id);

            if (result is null)
                throw new NotFoundException(ResourceMessagesExceptions.ORDER_BY_STATUS_NOT_FOUND);

            return new ResponseOrdersJson()
            {
                Orders = _mapper.Map<IList<ResponseOrderJson>>(result)
            };
                
        }
    }
}
