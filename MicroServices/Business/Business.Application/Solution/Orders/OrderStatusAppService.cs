using System;
using Business.Permissions;
using Business.Orders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Business.Localization;
using System.Linq;
using Volo.Abp;
using System.Threading.Tasks;

namespace Business.Orders
{
    public class OrderStatusAppService : CrudAppService<OrderStatus, OrderStatusDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateOrderStatusDto, CreateUpdateOrderStatusDto>,
        IOrderStatusAppService
    {
        protected override string GetPolicyName { get; set; } = BusinessPermissions.OrderStatus.Default;
        protected override string GetListPolicyName { get; set; } = BusinessPermissions.OrderStatus.Default;
        protected override string CreatePolicyName { get; set; } = BusinessPermissions.OrderStatus.Create;
        protected override string UpdatePolicyName { get; set; } = BusinessPermissions.OrderStatus.Update;
        protected override string DeletePolicyName { get; set; } = BusinessPermissions.OrderStatus.Delete;

        public OrderStatusAppService(IRepository<OrderStatus, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(BusinessResource);
        }

        public override async Task<OrderStatusDto> CreateAsync(CreateUpdateOrderStatusDto input)
        {
            await CheckCreatePolicyAsync();

            if (Repository.Any(a => a.Name == input.Name))
            {
                throw new UserFriendlyException(message: L["Error"], details: L["NameAlreadyExists", input.Name]);
            }

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }
    }
}