using MediatR;
using System;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class UpdateCollectionCommand : IRequest<CollectionDto>
{
    public Guid Id { get; set; }
    public UpdateCollectionRequestDto Request { get; set; } = new();

    public UpdateCollectionCommand(Guid id, UpdateCollectionRequestDto request)
    {
        Id = id;
        Request = request;
    }
}

