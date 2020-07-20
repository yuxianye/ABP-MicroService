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
    public class EquipmentBrandAppService : CrudAppService<EquipmentBrand, EquipmentBrandDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEquipmentBrandDto, CreateUpdateEquipmentBrandDto>,
        IEquipmentBrandAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EquipmentBrands.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EquipmentBrands.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EquipmentBrands.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EquipmentBrands.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EquipmentBrands.Delete;

        public EquipmentBrandAppService(IRepository<EquipmentBrand, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EquipmentBrandDto> CreateAsync(CreateUpdateEquipmentBrandDto input)
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