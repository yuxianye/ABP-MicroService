using System;
using Business.Suppliers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Suppliers
{
    public interface ISupplierLevelAppService :
        ICrudAppService< 
            SupplierLevelDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateSupplierLevelDto,
            CreateUpdateSupplierLevelDto>
    {

    }
}