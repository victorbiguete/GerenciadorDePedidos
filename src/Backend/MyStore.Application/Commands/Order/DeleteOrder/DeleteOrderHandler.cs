using AutoMapper;
using MediatR;
using MyStore.Domain.IRepository;
using MyStore.Domain.IRepository.Order;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommands>
    {
        private readonly IOrderReadRepository _repositoryMongo;
        private readonly IOrderWriteRepository _repositorySQL;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderHandler(IOrderReadRepository repositoryMongo, IOrderWriteRepository repositorySQL, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryMongo = repositoryMongo;
            _repositorySQL = repositorySQL;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(DeleteOrderCommands request, CancellationToken cancellationToken)
        {
            var result = await _repositoryMongo.GetByIdAsync(request.Id);

            if (result is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.ORDER_NOT_FOUND);
            }
            
            await _repositorySQL.Delete(result.Id);
            await _unitOfWork.Commit();
            await _repositoryMongo.Delete(result.Id);
        }
    }
}
