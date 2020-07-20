using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Linq;
using Volo.Abp;
using System.Threading.Tasks;

namespace Business.Enterprises
{
    public class EnterpriseWorkCenterAppService : CrudAppService<EnterpriseWorkCenter, EnterpriseWorkCenterDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseWorkCenterDto, CreateUpdateEnterpriseWorkCenterDto>,
        IEnterpriseWorkCenterAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EnterpriseWorkCenters.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EnterpriseWorkCenters.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkCenters.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkCenters.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkCenters.Delete;

        public EnterpriseWorkCenterAppService(IRepository<EnterpriseWorkCenter, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }


        public override async Task<EnterpriseWorkCenterDto> CreateAsync(CreateUpdateEnterpriseWorkCenterDto input)
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