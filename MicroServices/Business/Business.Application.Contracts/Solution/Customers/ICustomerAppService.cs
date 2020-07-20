using System;
using Business.Customers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Customers
{
    public interface ICustomerAppService :
        ICrudAppService<
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto,
            CreateUpdateCustomerDto>
    {

    }
}