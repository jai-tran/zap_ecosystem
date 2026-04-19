using System;
using MediatR;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.Commands
{
    public class DeleteCategoryCommand : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
