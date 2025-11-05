using AutoMapper;
using MediatR;
using MyStore.Communication.Response;
using MyStore.Domain.IRepository.Product;
using MyStore.Exceptions;
using MyStore.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Queries.Product.GetAllAsync
{
    public class GetAllAsyncHandler : IRequestHandler<GetAllAsyncQuerie, ResponseProductsJson>
    {
        private readonly IProductReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAsyncHandler(IProductReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseProductsJson> Handle(GetAllAsyncQuerie request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            if(products is null || products.Count() == 0)
            {
                throw new NotFoundException(ResourceMessagesExceptions.PRODUCT_NOT_FOUND);
            }

            return new ResponseProductsJson
            {
                Products = _mapper.Map<List<ResponseShortProductJson>>(products)
            };
        }
    }
}
