using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Customers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Customers
{


    public interface ICustomerAppService :
      ICrudAppService<
          CustomerDto,
          Guid,
          CustomerPagedAndSortedResultRequestDto,
          CreateUpdateCustomerDto,
          CreateUpdateCustomerDto>
    {
        Task Delete(List<Guid> ids);
    }

}