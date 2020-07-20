using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Localization;
using Business.Permissions;
using Business.Qualities.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Business.Qualities
{
    public class QualityInspectAppService : CrudAppService<QualityInspect, QualityInspectDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateQualityInspectDto, CreateUpdateQualityInspectDto>,
        IQualityInspectAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.QualityInspects.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.QualityInspects.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.QualityInspects.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.QualityInspects.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.QualityInspects.Delete;

        public QualityInspectAppService(IRepository<QualityInspect, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<QualityInspectDto> CreateAsync(CreateUpdateQualityInspectDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Code == input.Code))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["CodeAlreadyExists", input.Code]);
            }

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }
    }
}