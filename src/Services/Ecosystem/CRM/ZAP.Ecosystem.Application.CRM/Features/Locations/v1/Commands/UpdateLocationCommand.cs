using MediatR;
using System;
using ZAP.Ecosystem.Application.CRM.Features.Locations.v1.DTOs;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class UpdateLocationCommand : IRequest<object>
{
    public Guid Id { get; set; }
    public UpdateLocationRequestDto Request { get; set; } = new();
}
