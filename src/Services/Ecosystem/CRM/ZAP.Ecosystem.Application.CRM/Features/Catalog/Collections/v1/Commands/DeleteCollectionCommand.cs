using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class DeleteCollectionCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteCollectionCommand(Guid id)
    {
        Id = id;
    }
}

