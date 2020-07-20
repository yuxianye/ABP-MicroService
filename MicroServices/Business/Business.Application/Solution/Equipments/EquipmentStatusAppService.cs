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
    public class EquipmentStatusAppService : CrudAppService<EquipmentStatus, EquipmentStatusDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentStatusDto, CreateUpdateEquipmentStatusDto>,
        IEquipmentStatusAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentStatus.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentStatus.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentStatus.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentStatus.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentStatus.Delete;

        public EquipmentStatusAppService(IRepository<EquipmentStatus, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EquipmentStatusDto> CreateAsync(CreateUpdateEquipmentStatusDto input)
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