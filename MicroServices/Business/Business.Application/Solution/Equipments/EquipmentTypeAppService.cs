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
    public class EquipmentTypeAppService : CrudAppService<EquipmentType, EquipmentTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentTypeDto, CreateUpdateEquipmentTypeDto>,
        IEquipmentTypeAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentTypes.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentTypes.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentTypes.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentTypes.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentTypes.Delete;

        public EquipmentTypeAppService(IRepository<EquipmentType, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EquipmentTypeDto> CreateAsync(CreateUpdateEquipmentTypeDto input)
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