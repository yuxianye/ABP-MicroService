using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Equipments.Dtos
{
    public class CreateUpdateEquipmentInspectionDto
    {
        public Guid EquipmentId { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string InspectPerson { get; set; }

        public DateTime InspectionTime { get; set; }

        public Guid EquipmentInspectionResultId { get; set; }

        [StringLength(BusinessConsts.StringLength256)]
        public string Problem { get; set; }

        [StringLength(BusinessConsts.StringLength256)]
        public string Cause { get; set; }

        [StringLength(BusinessConsts.StringLength256)]
        public string Solution { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}