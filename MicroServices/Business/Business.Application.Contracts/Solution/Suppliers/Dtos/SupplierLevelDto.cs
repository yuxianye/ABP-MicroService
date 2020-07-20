using System;
using Volo.Abp.Application.Dtos;

namespace Business.Suppliers.Dtos
{
    public class SupplierLevelDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}