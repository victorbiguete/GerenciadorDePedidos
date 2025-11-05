using FluentValidation;
using MyStore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Commands.Order
{
    public class RegisterOrderValidator : AbstractValidator<RegisterOrderCommand>
    {
        public RegisterOrderValidator()
        {
            RuleFor(order => order.CustomerId)
                .GreaterThan(0)
                .WithMessage(ResourceMessagesExceptions.CUSTOMERID_LESS_THAN_1);

            RuleFor(order => order.Items)
                .NotEmpty()
                .WithMessage(ResourceMessagesExceptions.ITEMS_NOT_EMPTY);

            RuleFor(order => order.Items.Count)
                .GreaterThan(0)
                .WithMessage(ResourceMessagesExceptions.AT_LEAST_ONE_ITEM);

            RuleForEach(order => order.Items)
                .ChildRules(itemRule =>
                {
                    itemRule.RuleFor(item => item.ProductId)
                    .GreaterThan(0)
                    .WithMessage(ResourceMessagesExceptions.PRODUCTID_LESS_THAN_1);
                    
                    itemRule.RuleFor(item => item.Quantity)
                    .GreaterThan(0)
                    .WithMessage(ResourceMessagesExceptions.AT_LEAST_ONE_QUANTITY);
                });
        }
    }
}
