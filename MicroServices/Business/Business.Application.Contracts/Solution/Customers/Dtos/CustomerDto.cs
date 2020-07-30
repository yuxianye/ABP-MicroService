using System;
using Volo.Abp.Application.Dtos;

namespace Business.Customers.Dtos
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid CustomerLevelId { get; set; }

        public string CustomerLevelName { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Phone { get; set; }

        public string Remark { get; set; }
    }
}