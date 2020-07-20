using System;
using Business.Equipments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.Equipments
{
    public interface IEquipmentMaintenanceResultAppService :
        ICrudAppService< 
            EquipmentMaintenanceResultDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentMaintenanceResultDto,
            CreateUpdateEquipmentMaintenanceResultDto>
    {

    }
}