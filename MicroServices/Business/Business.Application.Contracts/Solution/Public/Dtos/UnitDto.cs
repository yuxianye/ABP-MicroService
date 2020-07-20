using System;
using Volo.Abp.Application.Dtos;

namespace Business.Public.Dtos
{
    public class UnitDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}