using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Equipments.Dtos
{
    public class CreateUpdateEquipmentMaintenanceDto
    {
        public Guid EquipmentId { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength256)]
        public string Problem { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength256)]
        public string Cause { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength256)]
        public string Solution { get; set; }

        public DateTime ActualStartTime { get; set; }

        public DateTime ActualFinishTime { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength256)]
        public string Consumable { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string ResponsiblePerson { get; set; }

        public DateTime MaintenanceTime { get; set; }

        public Guid EquipmentMaintenanceResultId { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}