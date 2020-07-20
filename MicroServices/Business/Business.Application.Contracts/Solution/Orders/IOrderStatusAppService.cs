using System;
using Business.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Orders
{
    public interface IOrderStatusAppService :
        ICrudAppService< 
            OrderStatusDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderStatusDto,
            CreateUpdateOrderStatusDto>
    {

    }
}