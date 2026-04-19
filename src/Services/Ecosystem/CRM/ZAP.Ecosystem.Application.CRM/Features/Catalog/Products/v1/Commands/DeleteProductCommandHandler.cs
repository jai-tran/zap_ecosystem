using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Products.v1.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, object>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id.ToString());
            if (product == null)
                return CrmResponse.NotFound("Product");

            await _repository.DeleteAsync(request.Id.ToString());

            return CrmResponse.Ok(new { id = request.Id }, "Product deleted successfully");
        }
    }
}
