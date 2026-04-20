using MediatR;
using System;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Queries;

public class GetCollectionByIdQuery : IRequest<CollectionDto>
{
    public Guid Id { get; set; }

    public GetCollectionByIdQuery(Guid id)
    {
        Id = id;
    }
}

