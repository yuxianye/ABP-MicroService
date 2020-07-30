using System;
using Volo.Abp.Application.Dtos;

namespace Business.Enterprises.Dtos
{
    public class EnterpriseAreaDto : EntityDto<Guid>
    {
        public Guid EnterpriseSiteId { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }

        public string Phone { get; set; }

        public string Remark { get; set; }
    }
}