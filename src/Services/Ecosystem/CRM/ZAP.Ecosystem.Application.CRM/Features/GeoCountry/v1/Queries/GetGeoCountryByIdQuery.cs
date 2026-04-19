using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Queries
{
    public class GetGeoCountryByIdQuery : IRequest<object>
    {
        public int id { get; set; }
    }

    public class GetGeoCountryByIdQueryHandler : IRequestHandler<GetGeoCountryByIdQuery, object>
    {
        private readonly IGeoCountryRepository _repository;

        public GetGeoCountryByIdQueryHandler(IGeoCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(GetGeoCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (x == null) return CrmResponse.NotFound("Country");

            var dto = new GeoCountryDto
            {
                id            = x.id,
                name          = x.Translations?.FirstOrDefault()?.name,
                serial_id     = x.serial_id,
                serial_number = x.serial_number,
                iso_alpha2    = x.iso_alpha2,
                iso_alpha3    = x.iso_alpha3,
                numeric_code  = x.numeric_code,
                dialing_code  = x.dialing_code,
                is_active     = x.is_active,
                latitude      = x.latitude,
                longitude     = x.longitude,
                geometry_data = x.geometry_data,
                flag_emoji    = x.flag_emoji,
                flag_url      = x.flag_url,
                created_at    = x.created_at,
                updated_at    = x.updated_at,
            };

            return CrmResponse.Ok(dto);
        }
    }
}
