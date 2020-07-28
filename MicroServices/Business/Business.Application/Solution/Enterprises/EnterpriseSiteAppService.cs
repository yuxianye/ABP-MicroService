using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Linq;
using Microsoft.EntityFrameworkCore;
using Business.Localization;
using Volo.Abp;

namespace Business.Enterprises
{
    public class EnterpriseSiteAppService : CrudAppService<EnterpriseSite, EnterpriseSiteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseSiteDto, CreateUpdateEnterpriseSiteDto>,
        IEnterpriseSiteAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EnterpriseSites.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EnterpriseSites.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EnterpriseSites.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EnterpriseSites.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EnterpriseSites.Delete;

        public EnterpriseSiteAppService(IRepository<EnterpriseSite, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<PagedResultDto<EnterpriseSiteDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            query = query.Include(a => a.Enterprise);
            var entities = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<EnterpriseSiteDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }

        public override async Task<EnterpriseSiteDto> CreateAsync(CreateUpdateEnterpriseSiteDto input)
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