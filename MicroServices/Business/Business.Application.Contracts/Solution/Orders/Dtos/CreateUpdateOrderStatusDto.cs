using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Orders.Dtos
{
    public class CreateUpdateOrderStatusDto
    {
        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}