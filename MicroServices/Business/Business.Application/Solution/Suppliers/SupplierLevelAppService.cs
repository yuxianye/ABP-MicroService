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
    public class SupplierLevelAppService : CrudAppService<SupplierLevel, SupplierLevelDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSupplierLevelDto, CreateUpdateSupplierLevelDto>,
        ISupplierLevelAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.SupplierLevels.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.SupplierLevels.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.SupplierLevels.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.SupplierLevels.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.SupplierLevels.Delete;

        public SupplierLevelAppService(IRepository<SupplierLevel, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<SupplierLevelDto> CreateAsync(CreateUpdateSupplierLevelDto input)
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