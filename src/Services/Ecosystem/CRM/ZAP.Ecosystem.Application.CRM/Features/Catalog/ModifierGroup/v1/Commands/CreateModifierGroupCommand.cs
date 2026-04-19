using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands
{
    public class CreateModifierGroupCommand : IRequest<object>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int MinSelection { get; set; }
        public int MaxSelection { get; set; } = 1;
        public bool IsRequired { get; set; }
        public int SortOrder { get; set; }
        public int? StatusId { get; set; } = 2101;
    }
}
