using System;
using Volo.Abp.Application.Dtos;

namespace Business.Qualities.Dtos
{
    public class QualityInspectDto : EntityDto<Guid>
    {
        public string Code { get; set; }

        public string InspectPerson { get; set; }

        public Guid QualityInspectTypeId { get; set; }

        public DateTime InspectTime { get; set; }

        public Guid QualityProblemLibId { get; set; }

        public Guid QualityInspectResultId { get; set; }

        public string Remark { get; set; }
    }
}