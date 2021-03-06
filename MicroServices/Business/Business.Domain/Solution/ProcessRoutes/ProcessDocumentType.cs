using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Business.ProcessRoutes
{
    /// <summary>
    /// 工序文件类型
    /// </summary>
    public class ProcessDocumentType : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 工序文件类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
