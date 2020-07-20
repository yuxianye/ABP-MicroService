using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Qualities.Dtos
{
    public class CreateUpdateQualityInspectDto
    {

        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string InspectPerson { get; set; }

        public Guid QualityInspectTypeId { get; set; }

        public DateTime InspectTime { get; set; }

        public Guid QualityProblemLibId { get; set; }

        public Guid QualityInspectResultId { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}