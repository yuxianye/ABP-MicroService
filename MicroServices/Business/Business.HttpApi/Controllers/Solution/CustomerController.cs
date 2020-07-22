using Business.Customers;
using Business.Customers.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Business.Controllers
{
    [Area("business")]
    [Route("api/business/customer")]
    public class CustomerController : BusinessController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost]
        public Task<CustomerDto> Create(CreateUpdateCustomerDto input)
        {
            return _customerAppService.CreateAsync(input);
        }

        [HttpPost]
        [Route("Delete")]
        public Task Delete(List<Guid> ids)
        {
            return _customerAppService.Delete(ids);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CustomerDto> Get(Guid id)
        {
            return _customerAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<PagedResultDto<CustomerDto>> GetAll(CustomerPagedAndSortedResultRequestDto input)
        {
            var result = _customerAppService.GetListAsync(input);
            //var a = result.Result.Items.First().CustomerLevelName;
            //System.Diagnostics.Debug.Print($"mingcheng{a}");
            return result;
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CustomerDto> Update(Guid id, CreateUpdateCustomerDto input)
        {
            return _customerAppService.UpdateAsync(id, input);
        }
    }
}
