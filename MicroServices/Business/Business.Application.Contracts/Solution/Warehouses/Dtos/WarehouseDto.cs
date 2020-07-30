using System;
using Volo.Abp.Application.Dtos;

namespace Business.Warehouses.Dtos
{
    public class WarehouseDto : EntityDto<Guid>
    {
        public Guid EnterpriseAreaId { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }

        public string Phone { get; set; }

        public string Remark { get; set; }
    }
}