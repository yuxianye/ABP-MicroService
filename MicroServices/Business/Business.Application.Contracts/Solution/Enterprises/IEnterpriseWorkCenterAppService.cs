using System;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Enterprises
{
    public interface IEnterpriseWorkCenterAppService :
        ICrudAppService< 
            EnterpriseWorkCenterDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEnterpriseWorkCenterDto,
            CreateUpdateEnterpriseWorkCenterDto>
    {

    }
}