using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Customers.Dtos
{
    public class CreateUpdateCustomerDto
    {
        //[Required]
        [StringLength(BusinessConsts.NameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 客户等级编号
        /// </summary>
        public Guid CustomerLevelId { get; set; }

        [StringLength(BusinessConsts.AddressLength)]
        public string Address { get; set; }

        [StringLength(BusinessConsts.NameLength)]
        public string Contact { get; set; }

        [Phone]
        [StringLength(BusinessConsts.PhoneLength)]
        public string Phone { get; set; }

        [StringLength(BusinessConsts.RemarkLength)]
        public string Remark { get; set; }






    }
}