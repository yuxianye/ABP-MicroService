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
    public class QualityInspectResultAppService : CrudAppService<QualityInspectResult, QualityInspectResultDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateQualityInspectResultDto, CreateUpdateQualityInspectResultDto>,
        IQualityInspectResultAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.QualityInspectResults.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.QualityInspectResults.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.QualityInspectResults.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.QualityInspectResults.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.QualityInspectResults.Delete;

        public QualityInspectResultAppService(IRepository<QualityInspectResult, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<QualityInspectResultDto> CreateAsync(CreateUpdateQualityInspectResultDto input)
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