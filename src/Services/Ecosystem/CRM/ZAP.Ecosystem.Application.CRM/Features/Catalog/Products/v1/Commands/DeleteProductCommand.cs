using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Products.v1.Commands
{
    public class DeleteProductCommand : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
