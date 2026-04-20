using MediatR;
using ZAP.Ecosystem.Application.CRM.Features.Locations.v1.DTOs;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class CreateLocationCommand : IRequest<object>
{
    public CreateLocationRequestDto Request { get; set; } = new();
}
