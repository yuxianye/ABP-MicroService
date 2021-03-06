using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Business.Materials.Dtos
{
    public class BOMDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid ProductId { get; set; }

        public string Version { get; set; }

        public Guid MaterialId { get; set; }

        public int Count { get; set; }

        public bool IsEnabled { get; set; }

        public string Remark { get; set; }
    }
}