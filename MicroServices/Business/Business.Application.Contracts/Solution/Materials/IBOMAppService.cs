using System;
using Business.Materials.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Materials
{
    public interface IBOMAppService :
        ICrudAppService< 
            BOMDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateBOMDto,
            CreateUpdateBOMDto>
    {

    }
}