using System;
using Volo.Abp.Application.Dtos;

namespace Business.Warehouses.Dtos
{
    public class WarehouseTypeDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}