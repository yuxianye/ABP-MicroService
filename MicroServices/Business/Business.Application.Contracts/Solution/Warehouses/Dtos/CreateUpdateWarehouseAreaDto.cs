using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Warehouses.Dtos
{
    public class CreateUpdateWarehouseAreaDto
    {
        public Guid WarehouseId { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}