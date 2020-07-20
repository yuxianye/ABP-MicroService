using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Linq;
using Volo.Abp;
using Business.Localization;

namespace Business.Enterprises
{

    public class EnterpriseAppService : CrudAppService<Enterprise, EnterpriseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseDto, CreateUpdateEnterpriseDto>,
        IEnterpriseAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Enterprises.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Enterprises.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Enterprises.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Enterprises.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Enterprises.Delete;

        public EnterpriseAppService(IRepository<Enterprise, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<EnterpriseDto> CreateAsync(CreateUpdateEnterpriseDto input)
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