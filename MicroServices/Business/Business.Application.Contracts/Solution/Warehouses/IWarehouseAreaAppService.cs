using System;
using Business.Warehouses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Warehouses
{
    public interface IWarehouseAreaAppService :
        ICrudAppService< 
            WarehouseAreaDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateWarehouseAreaDto,
            CreateUpdateWarehouseAreaDto>
    {

    }
}