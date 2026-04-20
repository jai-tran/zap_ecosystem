using MediatR;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class CreateCollectionCommand : IRequest<CollectionDto>
{
    public CreateCollectionRequestDto Request { get; set; } = new();
}

