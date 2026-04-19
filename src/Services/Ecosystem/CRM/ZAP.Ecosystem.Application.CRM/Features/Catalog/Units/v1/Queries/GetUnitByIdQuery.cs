using MediatR;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Queries;

public class GetUnitByIdQuery : IRequest<object>
{
    public int Id { get; set; }
}
