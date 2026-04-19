using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands
{
    public class UpdateModifierGroupCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? MinSelection { get; set; }
        public int? MaxSelection { get; set; }
        public bool? IsRequired { get; set; }
        public int? SortOrder { get; set; }
        public int? StatusId { get; set; }
    }
}
