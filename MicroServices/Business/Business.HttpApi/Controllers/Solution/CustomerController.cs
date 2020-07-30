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
    public class CustomerController : BusinessController, ICustomerAppService
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost]
        public Task<CustomerDto> Create(CreateUpdateCustomerDto input)
        {
            return _customerAppService.Create(input);
        }

        [HttpPost]
        [Route("Delete")]
        public Task Delete(List<Guid> ids)
        {
            return _customerAppService.Delete(ids);
        }

        [HttpPost]
        [Route("DeleteOne")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CustomerDto> Get(Guid id)
        {
            return _customerAppService.Get(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<PagedResultDto<CustomerDto>> GetAll(CustomerPagedAndSortedResultRequestDto input)
        {
            var result = _customerAppService.GetAll(input);
            //var a = result.Result.Items.First().CustomerLevelName;
            //System.Diagnostics.Debug.Print($"mingcheng{a}");
            return result;
        }

        //public Task<CustomerDto> GetAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        [Route("list")]
        public Task<PagedResultDto<CustomerDto>> GetListAsync(CustomerPagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CustomerDto> Update(Guid id, CreateUpdateCustomerDto input)
        {
            return _customerAppService.Update(id, input);
        }





        //public Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
