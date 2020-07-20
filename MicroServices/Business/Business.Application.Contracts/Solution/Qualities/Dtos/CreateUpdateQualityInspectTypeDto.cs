using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Qualities.Dtos
{
    public class CreateUpdateQualityInspectTypeDto
    {
        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}