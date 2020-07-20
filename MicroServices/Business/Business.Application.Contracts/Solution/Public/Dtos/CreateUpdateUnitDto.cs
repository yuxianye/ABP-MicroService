using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Public.Dtos
{
    public class CreateUpdateUnitDto
    {
        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}