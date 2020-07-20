using System;
using Business.Permissions;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Localization;
using Volo.Abp;

namespace Business.Enterprises
{
    public class EnterpriseAreaAppService : CrudAppService<EnterpriseArea, EnterpriseAreaDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEnterpriseAreaDto, CreateUpdateEnterpriseAreaDto>,
        IEnterpriseAreaAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.EnterpriseAreas.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.EnterpriseAreas.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.EnterpriseAreas.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.EnterpriseAreas.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.EnterpriseAreas.Delete;

        public EnterpriseAreaAppService(IRepository<EnterpriseArea, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<PagedResultDto<EnterpriseAreaDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            query = query.Include(a => a.EnterpriseSite);
            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<EnterpriseAreaDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }

        public override async Task<EnterpriseAreaDto> CreateAsync(CreateUpdateEnterpriseAreaDto input)
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