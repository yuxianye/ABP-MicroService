using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Enterprises.Dtos
{
    public class CreateUpdateEnterpriseWorkCenterDto
    {
        public Guid EnterpriseProductionLineId { get; set; }
     
        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.NameLength)]
        public string Manager { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}