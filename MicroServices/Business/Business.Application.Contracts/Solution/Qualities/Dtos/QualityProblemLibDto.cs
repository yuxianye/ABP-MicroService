using System;
using Volo.Abp.Application.Dtos;

namespace Business.Qualities.Dtos
{
    public class QualityProblemLibDto : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }
    }
}