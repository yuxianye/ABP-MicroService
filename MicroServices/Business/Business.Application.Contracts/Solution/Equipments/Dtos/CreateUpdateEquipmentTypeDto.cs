using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Equipments.Dtos
{
    public class CreateUpdateEquipmentTypeDto
    {
        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}