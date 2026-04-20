using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Shared.Data;

namespace ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Queries
{
    public class GetGeoCountryListQueryHandler : IRequestHandler<GetGeoCountryListQuery, object>
    {
        private readonly IGeoCountryRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public GetGeoCountryListQueryHandler(IGeoCountryRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<object> Handle(GetGeoCountryListQuery request, CancellationToken cancellationToken)
        {
            var req = request.Request;

            var (items, total) = await _repository.GetPagedAsync(
                req.PageIndex,
                req.PageSize,
                req.Filters?.IsActive,
                req.Search,
                req.Sort?.Field ?? "id",
                req.Sort?.Descending ?? false);

            var localeId = _currentUserService.LocaleId;

            var dtos = items.Select(x => new GeoCountryDto
            {
                id            = x.id,
                name          = x.Translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? string.Empty,
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
            }).ToList();

            return CrmResponse.Paged(new PagedResult<GeoCountryDto>(dtos, total, req.PageIndex, req.PageSize));
        }
    }
}
