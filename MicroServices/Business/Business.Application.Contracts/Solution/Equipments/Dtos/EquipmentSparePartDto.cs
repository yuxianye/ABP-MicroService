using System;
using Volo.Abp.Application.Dtos;

namespace Business.Equipments.Dtos
{
    public class EquipmentSparePartDto : EntityDto<Guid>
    {
        public Guid EquipmentSparePartTypeId { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }
    }
}