using System;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Equipments
{
    public interface IEquipmentTypeAppService :
        ICrudAppService< 
            EquipmentTypeDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentTypeDto,
            CreateUpdateEquipmentTypeDto>
    {

    }
}