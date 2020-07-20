using System;
using Volo.Abp.Application.Dtos;

namespace Business.Equipments.Dtos
{
    public class EquipmentStatusDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}