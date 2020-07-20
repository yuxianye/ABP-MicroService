using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using Volo.Abp;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Enterprises
{
    public class EnterpriseProductionLineAppService : CrudAppService<EnterpriseProductionLine, EnterpriseProductionLineDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseProductionLineDto, CreateUpdateEnterpriseProductionLineDto>,
        IEnterpriseProductionLineAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EnterpriseProductionLines.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EnterpriseProductionLines.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EnterpriseProductionLines.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EnterpriseProductionLines.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EnterpriseProductionLines.Delete;

        public EnterpriseProductionLineAppService(IRepository<EnterpriseProductionLine, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EnterpriseProductionLineDto> CreateAsync(CreateUpdateEnterpriseProductionLineDto input)
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