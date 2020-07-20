using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Business.Equipments
{
    /// <summary>
    /// 设备品牌
    /// </summary>
    public class EquipmentBrand : AuditedAggregateRoot<Guid>
    {

        /// <summary>
        /// 设备品牌名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }



        protected EquipmentBrand()
        {
        }

        public EquipmentBrand(
            Guid id,
            string name,
            string remark
        ) :base(id)
        {
            Name = name;
            Remark = remark;
        }
    }
}
