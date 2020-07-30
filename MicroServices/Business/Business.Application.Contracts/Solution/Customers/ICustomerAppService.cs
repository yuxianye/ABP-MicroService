using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Customers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerDto>> GetAll(CustomerPagedAndSortedResultRequestDto input);

        Task<CustomerDto> Get(Guid id);

        Task<CustomerDto> Create(CreateUpdateCustomerDto input);

        Task<CustomerDto> Update(Guid id, CreateUpdateCustomerDto input);

        Task Delete(List<Guid> ids);

    }

}