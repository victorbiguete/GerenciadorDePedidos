using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository;
using MyStore.Domain.IRepository.Order;
using MyStore.Domain.IRepository.OrderItens;
using MyStore.Domain.IRepository.Product;
using MyStore.Domain.ReadModel;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order
{
    public class RegisterOrderHandler : IRequestHandler<RegisterOrderCommand, ResponseOrderRegisterJson>
    {
        private readonly IOrderWriteRepository _repositoryWrite;
        private readonly IProductReadRepository _repositoryProductRead;
        private readonly IOrderReadRepository _repositoryMongo;
        private readonly IOrderItemReadRepository _repositoryOrderItemMongo;
        private readonly IOrderItemWriteOnlyRepository _repositoryOrderItem;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterOrderHandler(IOrderWriteRepository repositoryWrite, IProductReadRepository repositoryProductRead, IOrderReadRepository repositoryMongo, IOrderItemReadRepository repositoryOrderItemMongo, IOrderItemWriteOnlyRepository repositoryOrderItem, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryWrite = repositoryWrite;
            _repositoryProductRead = repositoryProductRead;
            _repositoryMongo = repositoryMongo;
            _repositoryOrderItemMongo = repositoryOrderItemMongo;
            _repositoryOrderItem = repositoryOrderItem;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseOrderRegisterJson> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var order = _mapper.Map<Domain.Entities.Order>(request);
            
            foreach(var orderItem in order.OrderItems)
            {
                var product = await _repositoryProductRead.GetByIdAsync(orderItem.ProductId);

                orderItem.UnitPrice = product.Price;
                orderItem.TotalPrice = orderItem.Quantity * orderItem.UnitPrice;
                orderItem.ProductName = product.Name;
                
                await _repositoryOrderItem.AddAsync(orderItem);
            }

            order.TotalAmount = order.OrderItems.Sum(item => item.TotalPrice);

            await _repositoryWrite.AddAsync(order);
            
            await _unitOfWork.Commit();

            var orderReadModel = _mapper.Map<OrderReadModel>(order);
            var orderItemReadModel = _mapper.Map<IList<OrderItemReadModel>>(order.OrderItems);

            await _repositoryMongo.AddAsync(orderReadModel);
            await _repositoryOrderItemMongo.AddAsync(orderItemReadModel);

            return _mapper.Map<ResponseOrderRegisterJson>(order);
        }

        private void Validate(RegisterOrderCommand request)
        {
            var validate = new RegisterOrderValidator().Validate(request);

            if (!validate.IsValid)
            {
                throw new ErrorOnValidationException(validate.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
            }
        }
    }
}
