using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Materials.Dtos
{
    public class CreateUpdateProductTypeDto
    {
        [Required]
        [StringLength(BusinessConsts.RemarkLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}