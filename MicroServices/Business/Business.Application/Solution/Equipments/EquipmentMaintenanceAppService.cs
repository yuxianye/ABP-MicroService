using System;
using Business.Permissions;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;

namespace Business.Equipments
{
    public class EquipmentMaintenanceAppService : CrudAppService<EquipmentMaintenance, EquipmentMaintenanceDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentMaintenanceDto, CreateUpdateEquipmentMaintenanceDto>,
        IEquipmentMaintenanceAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentMaintenances.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentMaintenances.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenances.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenances.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentMaintenances.Delete;

        public EquipmentMaintenanceAppService(IRepository<EquipmentMaintenance, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }
    }
}