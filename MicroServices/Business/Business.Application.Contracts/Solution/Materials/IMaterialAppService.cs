using System;
using Business.Materials.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Materials
{
    public interface IMaterialAppService :
        ICrudAppService< 
            MaterialDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateMaterialDto,
            CreateUpdateMaterialDto>
    {

    }
}