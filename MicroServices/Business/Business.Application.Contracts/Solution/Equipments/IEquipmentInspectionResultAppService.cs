using System;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Equipments
{
    public interface IEquipmentInspectionResultAppService :
        ICrudAppService< 
            EquipmentInspectionResultDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentInspectionResultDto,
            CreateUpdateEquipmentInspectionResultDto>
    {

    }
}