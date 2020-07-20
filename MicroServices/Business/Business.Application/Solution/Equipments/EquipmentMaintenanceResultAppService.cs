using System;
using Business.Permissions;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp;

namespace Business.Equipments
{
    public class EquipmentMaintenanceResultAppService : CrudAppService<EquipmentMaintenanceResult, EquipmentMaintenanceResultDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentMaintenanceResultDto, CreateUpdateEquipmentMaintenanceResultDto>,
        IEquipmentMaintenanceResultAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentMaintenanceResults.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentMaintenanceResults.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenanceResults.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenanceResults.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenanceResults.Delete;

        public EquipmentMaintenanceResultAppService(IRepository<EquipmentMaintenanceResult, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }


        public override async Task<EquipmentMaintenanceResultDto> CreateAsync(CreateUpdateEquipmentMaintenanceResultDto input)
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