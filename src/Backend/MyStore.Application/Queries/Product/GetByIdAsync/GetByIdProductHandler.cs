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

namespace MyStore.Application.Queries.Product.GetByIdAsync
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuerie, ResponseShortProductJson>
    {
        private readonly IProductReadRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdProductHandler(IProductReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseShortProductJson> Handle(GetByIdProductQuerie request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if(product is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.PRODUCT_NOT_FOUND);
            }

            return _mapper.Map<ResponseShortProductJson>(product);
        }
    }
}
