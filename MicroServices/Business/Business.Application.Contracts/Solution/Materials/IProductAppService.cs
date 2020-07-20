using System;
using Business.Materials.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Materials
{
    public interface IProductAppService :
        ICrudAppService< 
            ProductDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto,
            CreateUpdateProductDto>
    {

    }
}