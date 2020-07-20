using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Localization;
using Business.Permissions;
using Business.Warehouses.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Business.Warehouses
{
    public class WarehouseAppService : CrudAppService<Warehouse, WarehouseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateWarehouseDto, CreateUpdateWarehouseDto>,
        IWarehouseAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Warehouses.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Warehouses.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Warehouses.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Warehouses.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Warehouses.Delete;

        public WarehouseAppService(IRepository<Warehouse, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<WarehouseDto> CreateAsync(CreateUpdateWarehouseDto input)
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