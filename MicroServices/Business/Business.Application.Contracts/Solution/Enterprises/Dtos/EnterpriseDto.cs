using System;
using Volo.Abp.Application.Dtos;

namespace Business.Enterprises.Dtos
{
    public class EnterpriseDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Remark { get; set; }
    }
}