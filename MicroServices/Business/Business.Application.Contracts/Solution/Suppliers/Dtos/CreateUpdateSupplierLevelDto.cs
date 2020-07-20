using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Suppliers.Dtos
{
    public class CreateUpdateSupplierLevelDto
    {
        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}