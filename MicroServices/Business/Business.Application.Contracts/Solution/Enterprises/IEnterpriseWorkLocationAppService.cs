using System;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Enterprises
{
    public interface IEnterpriseWorkLocationAppService :
        ICrudAppService< 
            EnterpriseWorkLocationDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEnterpriseWorkLocationDto,
            CreateUpdateEnterpriseWorkLocationDto>
    {

    }
}