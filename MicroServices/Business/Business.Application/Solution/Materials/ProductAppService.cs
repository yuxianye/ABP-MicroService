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
    public class ProductAppService : CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto, CreateUpdateProductDto>,
        IProductAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Products.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Products.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Products.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Products.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Products.Delete;

        public ProductAppService(IRepository<Product, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
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