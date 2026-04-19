using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Commands
{
    public class CreateGeoCountryCommand : IRequest<object>
    {
        public int? serial_id { get; set; }
        public string? serial_number { get; set; }
        public string? iso_alpha2 { get; set; }
        public string? iso_alpha3 { get; set; }
        public int? numeric_code { get; set; }
        public string? dialing_code { get; set; }
        public bool is_active { get; set; } = true;
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string? geometry_data { get; set; }
        public string? flag_emoji { get; set; }
        public string? flag_url { get; set; }
    }

    public class CreateGeoCountryCommandHandler : IRequestHandler<CreateGeoCountryCommand, object>
    {
        private readonly IGeoCountryRepository _repository;

        public CreateGeoCountryCommandHandler(IGeoCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(CreateGeoCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.CRM.GeoCountry
            {
                serial_id     = request.serial_id,
                serial_number = request.serial_number,
                iso_alpha2    = request.iso_alpha2,
                iso_alpha3    = request.iso_alpha3,
                numeric_code  = request.numeric_code,
                dialing_code  = request.dialing_code,
                is_active     = request.is_active,
                latitude      = request.latitude,
                longitude     = request.longitude,
                geometry_data = request.geometry_data,
                flag_emoji    = request.flag_emoji,
                flag_url      = request.flag_url,
                created_at    = DateTime.UtcNow
            };

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return CrmResponse.Created(new { entity.id }, "Country created successfully");
        }
    }
}
