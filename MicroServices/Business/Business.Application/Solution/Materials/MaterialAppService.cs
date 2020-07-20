using System;
using Business.Permissions;
using Business.Materials.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp;

namespace Business.Materials
{
    public class MaterialAppService : CrudAppService<Material, MaterialDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMaterialDto, CreateUpdateMaterialDto>,
        IMaterialAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Materials.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Materials.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Materials.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Materials.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Materials.Delete;

        public MaterialAppService(IRepository<Material, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<MaterialDto> CreateAsync(CreateUpdateMaterialDto input)
        {
            await CheckCreatePolicyAsync();


            if (Repository.Any(a => a.Code == input.Code))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["CodeAlreadyExists", input.Name]);
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