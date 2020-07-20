using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Linq;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{

    public class BusinessDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IAsyncQueryableExecuter _queryableExecuter;

        private readonly IRepository<Business.Enterprises.Enterprise, Guid> _enterpriseRepository;
        private readonly IRepository<Business.Orders.OrderStatus, Guid> _orderStatusRepository;

        private readonly IRepository<Business.Equipments.EquipmentInspectionResult, Guid> _equipmentInspectionResultRepository;
        private readonly IRepository<Business.Equipments.EquipmentMaintenanceResult, Guid> _equipmentMaintenanceResultRepository;
        private readonly IRepository<Suppliers.SupplierLevel, Guid> _supplierLevelRepository;
        private readonly IRepository<Suppliers.Suppliers, Guid> _suppliersRepository;


        private readonly IRepository<Public.Unit> _unitRepository;


        public BusinessDataSeedContributor(
            IGuidGenerator guidGenerator,
            IAsyncQueryableExecuter queryableExecuter,
            IRepository<Business.Enterprises.Enterprise, Guid> enterpriseRepository,
            IRepository<Business.Orders.OrderStatus, Guid> orderStatusRepository,
            IRepository<Business.Equipments.EquipmentInspectionResult, Guid> equipmentInspectionResultRepository,
            IRepository<Business.Equipments.EquipmentMaintenanceResult, Guid> equipmentMaintenanceResultRepository,
            IRepository<Suppliers.SupplierLevel, Guid> supplierLevelRepository,
            IRepository<Suppliers.Suppliers, Guid> suppliersRepository,
            IRepository<Public.Unit> unitRepository
            )
        {
            _guidGenerator = guidGenerator;
            _queryableExecuter = queryableExecuter;
            _enterpriseRepository = enterpriseRepository;
            _orderStatusRepository = orderStatusRepository;
            _equipmentInspectionResultRepository = equipmentInspectionResultRepository;
            _equipmentMaintenanceResultRepository = equipmentMaintenanceResultRepository;
            _supplierLevelRepository = supplierLevelRepository;
            _suppliersRepository = suppliersRepository;
            _unitRepository = unitRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            for (int i = 1; i < 200; i++)
            {
                if (await _enterpriseRepository.AnyAsync(a => a.Name == $"新密第{i}耐火厂"))
                    await _enterpriseRepository.InsertAsync(
                        new Enterprises.Enterprise(_guidGenerator.Create(), $"新密第{i}耐火厂", $"新密市嵩山大道{i}号", "13800138000", $"测试数据{i}"));
            }


            if (await _orderStatusRepository.AnyAsync(a => a.Name == "新建"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "新建", null));
            if (await _orderStatusRepository.AnyAsync(a => a.Name == "已排产"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "已排产", null));
            if (await _orderStatusRepository.AnyAsync(a => a.Name == "生产中"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "生产中", null));
            if (await _orderStatusRepository.AnyAsync(a => a.Name == "生产完"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "生产完", null));
            if (await _orderStatusRepository.AnyAsync(a => a.Name == "待发货"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "待发货", null));
            if (await _orderStatusRepository.AnyAsync(a => a.Name == "撤销"))
                await _orderStatusRepository.InsertAsync(new Orders.OrderStatus(_guidGenerator.Create(), "撤销", null));


            if (await _equipmentInspectionResultRepository.AnyAsync(a => a.Name == "正常"))
                await _equipmentInspectionResultRepository.InsertAsync(new Equipments.EquipmentInspectionResult(_guidGenerator.Create(), "正常", null));
            if (await _equipmentInspectionResultRepository.AnyAsync(a => a.Name == "异常"))
                await _equipmentInspectionResultRepository.InsertAsync(new Equipments.EquipmentInspectionResult(_guidGenerator.Create(), "异常", null));
            if (await _equipmentInspectionResultRepository.AnyAsync(a => a.Name == "异常不影响生产"))
                await _equipmentInspectionResultRepository.InsertAsync(new Equipments.EquipmentInspectionResult(_guidGenerator.Create(), "异常不影响生产", null));
            if (await _equipmentInspectionResultRepository.AnyAsync(a => a.Name == "待检查"))
                await _equipmentInspectionResultRepository.InsertAsync(new Equipments.EquipmentInspectionResult(_guidGenerator.Create(), "待检查", null));


            if (await _equipmentMaintenanceResultRepository.AnyAsync(a => a.Name == "待维修"))
                await _equipmentMaintenanceResultRepository.InsertAsync(new Equipments.EquipmentMaintenanceResult(_guidGenerator.Create(), "待维修", null));
            if (await _equipmentMaintenanceResultRepository.AnyAsync(a => a.Name == "维修完成待观察"))
                await _equipmentMaintenanceResultRepository.InsertAsync(new Equipments.EquipmentMaintenanceResult(_guidGenerator.Create(), "维修完成待观察", null));
            if (await _equipmentMaintenanceResultRepository.AnyAsync(a => a.Name == "维修完成"))
                await _equipmentMaintenanceResultRepository.InsertAsync(new Equipments.EquipmentMaintenanceResult(_guidGenerator.Create(), "维修完成", null));
            if (await _equipmentMaintenanceResultRepository.AnyAsync(a => a.Name == "已正常"))
                await _equipmentMaintenanceResultRepository.InsertAsync(new Equipments.EquipmentMaintenanceResult(_guidGenerator.Create(), "已正常", null));



            if (await _supplierLevelRepository.AnyAsync(a => a.Name == "一级"))
                await _supplierLevelRepository.InsertAsync(new Suppliers.SupplierLevel(_guidGenerator.Create(), "一级", null));
            if (await _supplierLevelRepository.AnyAsync(a => a.Name == "二级"))
                await _supplierLevelRepository.InsertAsync(new Suppliers.SupplierLevel(_guidGenerator.Create(), "二级", null));
            if (await _supplierLevelRepository.AnyAsync(a => a.Name == "三级"))
                await _supplierLevelRepository.InsertAsync(new Suppliers.SupplierLevel(_guidGenerator.Create(), "三级", null));
            if (await _supplierLevelRepository.AnyAsync(a => a.Name == "四级"))
                await _supplierLevelRepository.InsertAsync(new Suppliers.SupplierLevel(_guidGenerator.Create(), "四级", null));
            if (await _supplierLevelRepository.AnyAsync(a => a.Name == "五级"))
                await _supplierLevelRepository.InsertAsync(new Suppliers.SupplierLevel(_guidGenerator.Create(), "五级", null));

            if (await _unitRepository.AnyAsync(a => a.Name == "吨"))
                await _unitRepository.InsertAsync(new Public.Unit(_guidGenerator.Create(), "吨", null));
            if (await _unitRepository.AnyAsync(a => a.Name == "箱"))
                await _unitRepository.InsertAsync(new Public.Unit(_guidGenerator.Create(), "箱", null));
            if (await _unitRepository.AnyAsync(a => a.Name == "米"))
                await _unitRepository.InsertAsync(new Public.Unit(_guidGenerator.Create(), "米", null));
            if (await _unitRepository.AnyAsync(a => a.Name == "千克"))
                await _unitRepository.InsertAsync(new Public.Unit(_guidGenerator.Create(), "千克", null));

        }
    }

}
