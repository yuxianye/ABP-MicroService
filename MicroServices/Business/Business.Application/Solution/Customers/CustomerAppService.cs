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
    [Authorize(BusinessPermissions.Customers.Default)]
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly IRepository<Customer, Guid> _repository;

        public CustomerAppService(IRepository<Customer, Guid> repository)
        {
            LocalizationResource = typeof(BusinessResource);
            _repository = repository;

        }

        [Authorize(BusinessPermissions.Customers.Create)]
        public async Task<CustomerDto> Create(CreateUpdateCustomerDto input)
        {
            if (_repository.Any(a => a.Name == input.Name))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }
            var result = await _repository.InsertAsync(ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input));

            return ObjectMapper.Map<Customer, CustomerDto>(result);
        }

        [Authorize(BusinessPermissions.Customers.Update)]
        public async Task<CustomerDto> Update(Guid id, CreateUpdateCustomerDto input)
        {
            if (_repository.Any(a => a.Name == input.Name && a.Id != id))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }
            var result = await _repository.UpdateAsync(ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input));
            return ObjectMapper.Map<Customer, CustomerDto>(result);
        }


        [Authorize(BusinessPermissions.Customers.Delete)]
        public async Task Delete(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                await _repository.DeleteAsync(id);
            }
        }

        public async Task<PagedResultDto<CustomerDto>> GetAll(CustomerPagedAndSortedResultRequestDto input)
        {

            var query = _repository.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), _ => _.Name.Contains(input.Filter) || _.Phone.Contains(input.Filter));
            var items = await query.OrderBy(_ => _.LastModificationTime)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
                    .ToListAsync();

            var dots = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(items);
            var totalCount = await query.CountAsync();
            return new PagedResultDto<CustomerDto>(totalCount, dots);

        }

        public async Task<CustomerDto> Get(Guid id)
        {
            var result = await _repository.GetAsync(id);

            return ObjectMapper.Map<Customer, CustomerDto>(result);

        }
    }

}