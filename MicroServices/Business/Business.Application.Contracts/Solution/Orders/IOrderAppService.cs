using System;
using Business.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Orders
{
    public interface IOrderAppService :
        ICrudAppService< 
            OrderDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderDto,
            CreateUpdateOrderDto>
    {

    }
}