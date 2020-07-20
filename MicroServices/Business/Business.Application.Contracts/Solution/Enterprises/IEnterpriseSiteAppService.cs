using System;
using Business.Enterprises.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Enterprises
{
    public interface IEnterpriseSiteAppService :
        ICrudAppService< 
            EnterpriseSiteDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEnterpriseSiteDto,
            CreateUpdateEnterpriseSiteDto>
    {

    }
}