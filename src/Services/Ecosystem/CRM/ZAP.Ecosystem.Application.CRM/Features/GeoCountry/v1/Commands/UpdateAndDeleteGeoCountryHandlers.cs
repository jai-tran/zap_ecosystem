using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Commands
{
    public class UpdateGeoCountryCommand : IRequest<object>
    {
        public int id { get; set; }
        public int? serial_id { get; set; }
        public string? serial_number { get; set; }
        public string? iso_alpha2 { get; set; }
        public string? iso_alpha3 { get; set; }
        public int? numeric_code { get; set; }
        public string? dialing_code { get; set; }
        public bool is_active { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string? geometry_data { get; set; }
        public string? flag_emoji { get; set; }
        public string? flag_url { get; set; }
    }

    public class DeleteGeoCountryCommand : IRequest<object>
    {
        public int id { get; set; }
    }

    public class UpdateGeoCountryCommandHandler : IRequestHandler<UpdateGeoCountryCommand, object>
    {
        private readonly IGeoCountryRepository _repository;

        public UpdateGeoCountryCommandHandler(IGeoCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(UpdateGeoCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (entity == null) return CrmResponse.NotFound("Country");

            entity.serial_id     = request.serial_id;
            entity.serial_number = request.serial_number;
            entity.iso_alpha2    = request.iso_alpha2;
            entity.iso_alpha3    = request.iso_alpha3;
            entity.numeric_code  = request.numeric_code;
            entity.dialing_code  = request.dialing_code;
            entity.is_active     = request.is_active;
            entity.latitude      = request.latitude;
            entity.longitude     = request.longitude;
            entity.geometry_data = request.geometry_data;
            entity.flag_emoji    = request.flag_emoji;
            entity.flag_url      = request.flag_url;
            entity.updated_at    = DateTime.UtcNow;

            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return CrmResponse.Updated(null, "Country updated successfully");
        }
    }

    public class DeleteGeoCountryCommandHandler : IRequestHandler<DeleteGeoCountryCommand, object>
    {
        private readonly IGeoCountryRepository _repository;

        public DeleteGeoCountryCommandHandler(IGeoCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(DeleteGeoCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (entity == null) return CrmResponse.NotFound("Country");

            await _repository.DeleteAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return CrmResponse.Ok(null, "Country deleted successfully");
        }
    }
}
