using System;
using Business.Public.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Public
{
    public interface IUnitAppService :
        ICrudAppService< 
            UnitDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateUnitDto,
            CreateUpdateUnitDto>
    {

    }
}