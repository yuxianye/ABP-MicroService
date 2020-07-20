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
    public class ProductTypeAppService : CrudAppService<ProductType, ProductTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductTypeDto, CreateUpdateProductTypeDto>,
        IProductTypeAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.ProductTypes.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.ProductTypes.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.ProductTypes.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.ProductTypes.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.ProductTypes.Delete;

        public ProductTypeAppService(IRepository<ProductType, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<ProductTypeDto> CreateAsync(CreateUpdateProductTypeDto input)
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