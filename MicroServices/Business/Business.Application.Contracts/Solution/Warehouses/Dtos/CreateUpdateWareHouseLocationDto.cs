using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Warehouses.Dtos
{
    public class CreateUpdateWarehouseLocationDto
    {
        public Guid WareHouseAreaId { get; set; }

        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}