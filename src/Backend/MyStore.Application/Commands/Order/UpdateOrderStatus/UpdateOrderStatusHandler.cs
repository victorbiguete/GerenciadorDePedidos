using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.Entities;
using MyStore.Domain.IRepository;
using MyStore.Domain.IRepository.Order;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommands>
    {
        private readonly IOrderReadRepository _repositoryMongo;
        private readonly IOrderUpdateOnlyRepository _repositorySQL;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderStatusHandler(IOrderReadRepository repositoryMongo, IOrderUpdateOnlyRepository repositorySQL, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryMongo = repositoryMongo;
            _repositorySQL = repositorySQL;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderStatusCommands request, CancellationToken cancellationToken)
        {
            var orderReadModel = await _repositoryMongo.GetByIdAsync(request.Id);

            if (orderReadModel is null)
                throw new NotFoundException(ResourceMessagesExceptions.ORDER_NOT_FOUND);

            orderReadModel.Status = request.Status;

            var order = _mapper.Map<Domain.Entities.Order>(orderReadModel);

            _repositorySQL.Update(order);
            await _unitOfWork.Commit();

            await _repositoryMongo.Update(orderReadModel);
        }
    }
}
