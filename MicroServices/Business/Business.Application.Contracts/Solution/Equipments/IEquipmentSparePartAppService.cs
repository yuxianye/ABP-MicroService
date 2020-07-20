using System;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Equipments
{
    public interface IEquipmentSparePartAppService :
        ICrudAppService< 
            EquipmentSparePartDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentSparePartDto,
            CreateUpdateEquipmentSparePartDto>
    {

    }
}