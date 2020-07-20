using System;
using Volo.Abp.Application.Dtos;

namespace Business.Enterprises.Dtos
{
    public class EnterpriseWorkCenterDto : AuditedEntityDto<Guid>
    {
        public Guid EnterpriseProductionLineId { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }

        public string Remark { get; set; }
    }
}