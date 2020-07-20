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
    public class WarehouseTypeAppService : CrudAppService<WarehouseType, WarehouseTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateWarehouseTypeDto, CreateUpdateWarehouseTypeDto>,
        IWarehouseTypeAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.WarehouseTypes.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.WarehouseTypes.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.WarehouseTypes.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.WarehouseTypes.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.WarehouseTypes.Delete;

        public WarehouseTypeAppService(IRepository<WarehouseType, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<WarehouseTypeDto> CreateAsync(CreateUpdateWarehouseTypeDto input)
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