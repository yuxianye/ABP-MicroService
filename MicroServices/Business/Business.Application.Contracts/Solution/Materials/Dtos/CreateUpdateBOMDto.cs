using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Materials.Dtos
{
    public class CreateUpdateBOMDto
    {
        [Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [StringLength(BusinessConsts.StringLength64)]
        public string Version { get; set; }

        public Guid MaterialId { get; set; }

        public int Count { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}