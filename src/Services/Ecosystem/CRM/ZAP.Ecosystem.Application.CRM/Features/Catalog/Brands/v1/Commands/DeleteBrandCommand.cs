using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

public class DeleteBrandCommand : IRequest<object>
{
    public Guid Id { get; set; }
}
