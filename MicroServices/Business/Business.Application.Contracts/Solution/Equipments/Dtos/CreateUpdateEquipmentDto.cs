using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Equipments.Dtos
{
    public class CreateUpdateEquipmentDto
    {
        public Guid EquipmentTypeId { get; set; }

        public Guid EquipmentBrandId { get; set; }

        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }
     
        [Required]
        [StringLength(BusinessConsts.StringLength64)]
        public string Specification { get; set; }

        public DateTime ManufactureDate { get; set; }

        public Guid EquipmentStatusId { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}