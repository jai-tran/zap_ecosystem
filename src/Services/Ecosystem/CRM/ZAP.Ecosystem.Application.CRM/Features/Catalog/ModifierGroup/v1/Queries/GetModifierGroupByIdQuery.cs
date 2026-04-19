using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Queries
{
    public class GetModifierGroupByIdQuery : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
