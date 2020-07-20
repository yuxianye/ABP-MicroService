using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Orders.Dtos
{
    public class CreateUpdateOrderDto
    {
        [Required]
        [StringLength(BusinessConsts.CodeLength)]
        public int Code { get; set; }

        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }

        [Range(1,int.MaxValue)]
        public int Count { get; set; }

        public Guid OrderStatusID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }
    }
}