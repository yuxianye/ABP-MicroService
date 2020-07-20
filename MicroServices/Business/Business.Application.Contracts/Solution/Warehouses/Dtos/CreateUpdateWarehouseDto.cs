using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Warehouses.Dtos
{
    public class CreateUpdateWarehouseDto
    {
        public Guid EnterpriseAreaId { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.NameLength)]
        public string Manager { get; set; }

        [Phone]
        [StringLength(BusinessConsts.PhoneLength)]
        public string Phone { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}