using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Enterprises.Dtos
{
    public class CreateUpdateEnterpriseSiteDto
    {
        public Guid EnterpriseId { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.AddressLength)]
        public string Address { get; set; }

        [StringLength(BusinessConsts.NameLength)]
        public string Manager { get; set; }

        [Phone]
        [StringLength(BusinessConsts.PhoneLength)]
        public string Phone { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}