using MediatR;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Commands
{
    public class DeleteUnitCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
}
