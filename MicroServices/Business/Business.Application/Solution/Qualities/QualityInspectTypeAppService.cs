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
    public class QualityInspectTypeAppService : CrudAppService<QualityInspectType, QualityInspectTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateQualityInspectTypeDto, CreateUpdateQualityInspectTypeDto>,
        IQualityInspectTypeAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.QualityInspectTypes.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.QualityInspectTypes.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.QualityInspectTypes.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.QualityInspectTypes.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.QualityInspectTypes.Delete;

        public QualityInspectTypeAppService(IRepository<QualityInspectType, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<QualityInspectTypeDto> CreateAsync(CreateUpdateQualityInspectTypeDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Name == input.Name))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }


    }
}