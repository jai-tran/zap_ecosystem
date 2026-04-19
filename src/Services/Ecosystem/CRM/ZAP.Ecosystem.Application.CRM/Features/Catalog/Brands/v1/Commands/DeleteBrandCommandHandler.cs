using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, object>
{
    private readonly IBrandRepository _repository;

    public DeleteBrandCommandHandler(IBrandRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand == null)
            return CrmResponse.NotFound("Brand");

        await _repository.DeleteAsync(request.Id);

        return CrmResponse.Ok(new { id = request.Id }, "Deleted successfully");
    }
}
