using System;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Enterprises
{
    public interface IEnterpriseProductionLineAppService :
        ICrudAppService< 
            EnterpriseProductionLineDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEnterpriseProductionLineDto,
            CreateUpdateEnterpriseProductionLineDto>
    {

    }
}