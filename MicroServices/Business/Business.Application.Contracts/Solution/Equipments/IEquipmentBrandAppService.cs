using System;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Equipments
{
    public interface IEquipmentBrandAppService :
        ICrudAppService< 
            EquipmentBrandDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentBrandDto,
            CreateUpdateEquipmentBrandDto>
    {

    }
}