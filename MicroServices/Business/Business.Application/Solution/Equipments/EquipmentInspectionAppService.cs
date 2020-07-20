using System;
using Business.Permissions;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;

namespace Business.Equipments
{
    public class EquipmentInspectionAppService : CrudAppService<EquipmentInspection, EquipmentInspectionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentInspectionDto, CreateUpdateEquipmentInspectionDto>,
        IEquipmentInspectionAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentInspections.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentInspections.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentInspections.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentInspections.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentInspections.Delete;

        public EquipmentInspectionAppService(IRepository<EquipmentInspection, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }
    }
}