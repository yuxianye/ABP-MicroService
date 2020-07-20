using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Threading.Tasks;
using Volo.Abp;
using System.Linq;

namespace Business.Enterprises
{
    public class EnterpriseWorkLocationAppService : CrudAppService<EnterpriseWorkLocation, EnterpriseWorkLocationDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseWorkLocationDto, CreateUpdateEnterpriseWorkLocationDto>,
        IEnterpriseWorkLocationAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EnterpriseWorkLocations.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EnterpriseWorkLocations.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkLocations.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkLocations.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EnterpriseWorkLocations.Delete;

        public EnterpriseWorkLocationAppService(IRepository<EnterpriseWorkLocation, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EnterpriseWorkLocationDto> CreateAsync(CreateUpdateEnterpriseWorkLocationDto input)
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