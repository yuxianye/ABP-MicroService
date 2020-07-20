using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Localization;
using Business.Permissions;
using Business.Public.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Business.Public
{
    public class UnitAppService : CrudAppService<Unit, UnitDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUnitDto, CreateUpdateUnitDto>,
        IUnitAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Units.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Units.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Units.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Units.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Units.Delete;

        public UnitAppService(IRepository<Unit, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<UnitDto> CreateAsync(CreateUpdateUnitDto input)
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