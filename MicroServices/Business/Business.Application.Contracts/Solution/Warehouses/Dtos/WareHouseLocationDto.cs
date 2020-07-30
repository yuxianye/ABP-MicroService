using System;
using Volo.Abp.Application.Dtos;

namespace Business.Warehouses.Dtos
{
    public class WarehouseLocationDto : EntityDto<Guid>
    {
        public Guid WareHouseAreaId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }
    }
}