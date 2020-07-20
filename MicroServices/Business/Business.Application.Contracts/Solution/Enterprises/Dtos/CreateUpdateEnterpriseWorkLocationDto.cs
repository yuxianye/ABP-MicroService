using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Enterprises.Dtos
{
    public class CreateUpdateEnterpriseWorkLocationDto
    {
        public Guid EnterpriseWorkCenterId { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        public Guid EquipmentId { get; set; }

        public Guid ProcessId { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}