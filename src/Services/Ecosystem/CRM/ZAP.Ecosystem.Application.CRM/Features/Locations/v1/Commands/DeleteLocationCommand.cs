using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class DeleteLocationCommand : IRequest<object>
{
    public Guid Id { get; set; }
}
