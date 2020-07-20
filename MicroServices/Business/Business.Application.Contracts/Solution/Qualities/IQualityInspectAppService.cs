using System;
using Business.Qualities.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Qualities
{
    public interface IQualityInspectAppService :
        ICrudAppService< 
            QualityInspectDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateQualityInspectDto,
            CreateUpdateQualityInspectDto>
    {

    }
}