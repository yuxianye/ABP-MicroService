using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Materials.Dtos
{
    public class CreateUpdateMaterialDto
    {
        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength64)]
        public string Specification { get; set; }

        public Guid UnitId { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }




    }
}