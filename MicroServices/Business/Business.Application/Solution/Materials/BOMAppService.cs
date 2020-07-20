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
    public class BOMAppService : CrudAppService<BOM, BOMDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBOMDto, CreateUpdateBOMDto>,
        IBOMAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.BOMs.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.BOMs.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.BOMs.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.BOMs.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.BOMs.Delete;

        public BOMAppService(IRepository<BOM, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<BOMDto> CreateAsync(CreateUpdateBOMDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Name == input.Name))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }


            if (Repository.Any(a => a.ProductId == input.ProductId && a.MaterialId==input.MaterialId && a.Version==input.Version))
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