using System;
using Business.Permissions;
using Business.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp;

namespace Business.Orders
{
    public class OrderAppService : CrudAppService<Order, OrderDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateOrderDto, CreateUpdateOrderDto>,
        IOrderAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.Orders.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.Orders.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.Orders.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.Orders.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.Orders.Delete;

        public OrderAppService(IRepository<Order, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }


        public override async Task<OrderDto> CreateAsync(CreateUpdateOrderDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Code == input.Code))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["CodeAlreadyExists", input.Code]);
            }

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }
    }
}