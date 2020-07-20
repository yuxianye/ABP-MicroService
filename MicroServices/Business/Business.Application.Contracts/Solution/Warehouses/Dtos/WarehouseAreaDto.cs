using System;
using Volo.Abp.Application.Dtos;

namespace Business.Warehouses.Dtos
{
    public class WarehouseAreaDto : AuditedEntityDto<Guid>
    {
        public Guid WarehouseId { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }
    }
}