using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Localization;
using Business.Permissions;
using Business.Suppliers.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Business.Suppliers
{
    public class SuppliersAppService : CrudAppService<Suppliers, SuppliersDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSuppliersDto, CreateUpdateSuppliersDto>,
        ISuppliersAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Suppliers.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Suppliers.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Suppliers.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Suppliers.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Suppliers.Delete;

        public SuppliersAppService(IRepository<Suppliers, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<SuppliersDto> CreateAsync(CreateUpdateSuppliersDto input)
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