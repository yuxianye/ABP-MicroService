using System;
using Business.Suppliers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Suppliers
{
    public interface ISuppliersAppService :
        ICrudAppService< 
            SuppliersDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateSuppliersDto,
            CreateUpdateSuppliersDto>
    {

    }
}