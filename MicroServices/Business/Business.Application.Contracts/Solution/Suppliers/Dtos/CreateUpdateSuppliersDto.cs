using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Suppliers.Dtos
{
    public class CreateUpdateSuppliersDto
    {
        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        public Guid SupplierLevelId { get; set; }

        [StringLength(BusinessConsts.NameLength)]
        public string Contact { get; set; }

        [Phone]
        [StringLength(BusinessConsts.PhoneLength)]
        public string Phone { get; set; }

        [Phone]
        [StringLength(BusinessConsts.PhoneLength)]
        public string Fax { get; set; }

        [StringLength(BusinessConsts.AddressLength)]
        public string Address { get; set; }

        [EmailAddress]
        [StringLength(BusinessConsts.EmailLength)]
        public string Email { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}