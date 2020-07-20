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
    public class EquipmentSparePartTypeAppService : CrudAppService<EquipmentSparePartType, EquipmentSparePartTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentSparePartTypeDto, CreateUpdateEquipmentSparePartTypeDto>,
        IEquipmentSparePartTypeAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentSparePartTypes.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentSparePartTypes.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentSparePartTypes.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentSparePartTypes.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentSparePartTypes.Delete;

        public EquipmentSparePartTypeAppService(IRepository<EquipmentSparePartType, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EquipmentSparePartTypeDto> CreateAsync(CreateUpdateEquipmentSparePartTypeDto input)
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