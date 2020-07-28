using System;
using Business.Permissions;
using Business.Customers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Business.Localization;
using Volo.Abp;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Customers
{
    public class CustomerAppService : CrudAppService<Customer, CustomerDto, Guid, CustomerPagedAndSortedResultRequestDto, CreateUpdateCustomerDto, CreateUpdateCustomerDto>,
    ICustomerAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Customers.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Customers.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Customers.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Customers.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Customers.Delete;

        public CustomerAppService(IRepository<Customer, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        protected override IQueryable<Customer> CreateFilteredQuery(CustomerPagedAndSortedResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), _ => _.Name.Contains(input.Filter) || _.Phone.Contains(input.Filter));
            query = query.Include(a => a.CustomerLeve);
            return query;
        }

        public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
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

        public override async Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {

            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            var count = Repository.Count(a => a.Name == input.Name && entity.Id != id);
            //if (Repository.Any (a=>a.Name == input.Name && entity.Id != id))

            if (count > 0)
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }

            MapToEntity(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);

        }


        [Authorize(BusinessPermissions.Customers.Delete)]
        public async Task Delete(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                await Repository.DeleteAsync(id);
            }
        }

    }

}