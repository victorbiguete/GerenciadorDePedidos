using AutoMapper;
using MyStore.Application.Commands.Order;
using MyStore.Application.Commands.OrderItens;
using MyStore.Communication.Response;
using MyStore.Domain.Entities;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
            EntityToReadModel();
        }

        private void RequestToDomain()
        {
            CreateMap<RegisterOrderItemCommand, OrderItem>();
            CreateMap<RegisterOrderCommand, Order>()
                .ForMember(dest=> dest.OrderItems, config => config.MapFrom(source => source.Items));
            
        }

        private void EntityToReadModel()
        {
            CreateMap<Order, OrderReadModel>().ReverseMap()
                .ForMember(dest=> dest.OrderItems, config => config.MapFrom(source => source.OrderItems));
            CreateMap<OrderItem,OrderItemReadModel>().ReverseMap();
        }

        private void DomainToResponse()
        {
            CreateMap<CustomerReadModel, ResponseShortCustomerJson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id));

            CreateMap<ProductReadModel, ResponseShortProductJson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id));

            CreateMap<Order, ResponseOrderRegisterJson>()
                .ForMember(dest => dest.OrderId, config => config.MapFrom(source => source.Id));

            CreateMap<OrderReadModel, ResponseOrderJson>();
            CreateMap<OrderItemReadModel, ResponseOrderItemJson>();

        }
    }
}
