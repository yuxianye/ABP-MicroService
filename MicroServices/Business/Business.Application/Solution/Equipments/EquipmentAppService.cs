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
    public class EquipmentAppService : CrudAppService<Equipment, EquipmentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentDto, CreateUpdateEquipmentDto>,
        IEquipmentAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Equipments.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Equipments.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Equipments.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Equipments.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Equipments.Delete;

        public EquipmentAppService(IRepository<Equipment, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EquipmentDto> CreateAsync(CreateUpdateEquipmentDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Code == input.Code))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["CodeAlreadyExists", input.Code]);
            }

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