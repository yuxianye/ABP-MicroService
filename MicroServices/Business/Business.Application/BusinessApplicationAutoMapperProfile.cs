using AutoMapper;
using Business.BaseData;
using Business.BaseData.DataDictionaryManagement.Dto;
using Business.BaseData.EmployeeManagement.Dto;
using Business.BaseData.JobManagement.Dto;
using Business.BaseData.OrganizationManagement.Dto;
using Business.Enterprises;
using Business.Enterprises.Dtos;
using Business.Equipments;
using Business.Equipments.Dtos;
using Business.Materials;
using Business.Materials.Dtos;
using Business.Public;
using Business.Public.Dtos;
using Business.Qualities;
using Business.Qualities.Dtos;
using Business.Suppliers;
using Business.Suppliers.Dtos;
using Business.Warehouses;
using Business.Customers;
using Business.Customers.Dtos;
using Business.Orders;
using Business.Orders.Dtos;
using Business.Warehouses.Dtos;

namespace Business
{
    public class BusinessApplicationAutoMapperProfile : Profile
    {
        public BusinessApplicationAutoMapperProfile()
        {
            CreateMap<DataDictionary, DictionaryDto>();

            CreateMap<DataDictionaryDetail, DictionaryDetailDto>();

            CreateMap<Organization, OrganizationDto>()
                .ForMember(dto => dto.Label, opt => opt.MapFrom(src => src.Name));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<Job, JobDto>();



            CreateMap<Enterprise, EnterpriseDto>();
            CreateMap<CreateUpdateEnterpriseDto, Enterprise>(MemberList.Source);
            CreateMap<EnterpriseArea, EnterpriseAreaDto>();
            CreateMap<CreateUpdateEnterpriseAreaDto, EnterpriseArea>(MemberList.Source);
            CreateMap<EnterpriseProductionLine, EnterpriseProductionLineDto>();
            CreateMap<CreateUpdateEnterpriseProductionLineDto, EnterpriseProductionLine>(MemberList.Source);
            CreateMap<EnterpriseSite, EnterpriseSiteDto>().ForMember(a => a.EnterpriseName, b => b.MapFrom(c => c.Enterprise.Name));
            CreateMap<CreateUpdateEnterpriseSiteDto, EnterpriseSite>(MemberList.Source);
            CreateMap<EnterpriseWorkCenter, EnterpriseWorkCenterDto>();
            CreateMap<CreateUpdateEnterpriseWorkCenterDto, EnterpriseWorkCenter>(MemberList.Source);
            CreateMap<EnterpriseWorkLocation, EnterpriseWorkLocationDto>();
            CreateMap<CreateUpdateEnterpriseWorkLocationDto, EnterpriseWorkLocation>(MemberList.Source);
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<CreateUpdateEquipmentDto, Equipment>(MemberList.Source);
            CreateMap<EquipmentBrand, EquipmentBrandDto>();
            CreateMap<CreateUpdateEquipmentBrandDto, EquipmentBrand>(MemberList.Source);
            CreateMap<EquipmentInspection, EquipmentInspectionDto>();
            CreateMap<CreateUpdateEquipmentInspectionDto, EquipmentInspection>(MemberList.Source);
            CreateMap<EquipmentInspectionResult, EquipmentInspectionResultDto>();
            CreateMap<CreateUpdateEquipmentInspectionResultDto, EquipmentInspectionResult>(MemberList.Source);
            CreateMap<EquipmentMaintenance, EquipmentMaintenanceDto>();
            CreateMap<CreateUpdateEquipmentMaintenanceDto, EquipmentMaintenance>(MemberList.Source);
            CreateMap<EquipmentMaintenanceResult, EquipmentMaintenanceResultDto>();
            CreateMap<CreateUpdateEquipmentMaintenanceResultDto, EquipmentMaintenanceResult>(MemberList.Source);
            CreateMap<EquipmentSparePart, EquipmentSparePartDto>();
            CreateMap<CreateUpdateEquipmentSparePartDto, EquipmentSparePart>(MemberList.Source);
            CreateMap<EquipmentSparePartType, EquipmentSparePartTypeDto>();
            CreateMap<CreateUpdateEquipmentSparePartTypeDto, EquipmentSparePartType>(MemberList.Source);
            CreateMap<EquipmentStatus, EquipmentStatusDto>();
            CreateMap<CreateUpdateEquipmentStatusDto, EquipmentStatus>(MemberList.Source);
            CreateMap<EquipmentType, EquipmentTypeDto>();
            CreateMap<CreateUpdateEquipmentTypeDto, EquipmentType>(MemberList.Source);
            CreateMap<Material, MaterialDto>();
            CreateMap<CreateUpdateMaterialDto, Material>(MemberList.Source);
            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>(MemberList.Source);
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<CreateUpdateProductTypeDto, ProductType>(MemberList.Source);
            CreateMap<BOM, BOMDto>();
            CreateMap<CreateUpdateBOMDto, BOM>(MemberList.Source);
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>(MemberList.Source);
            CreateMap<QualityInspect, QualityInspectDto>();
            CreateMap<CreateUpdateQualityInspectDto, QualityInspect>(MemberList.Source);
            CreateMap<QualityInspectResult, QualityInspectResultDto>();
            CreateMap<CreateUpdateQualityInspectResultDto, QualityInspectResult>(MemberList.Source);
            CreateMap<QualityInspectType, QualityInspectTypeDto>();
            CreateMap<CreateUpdateQualityInspectTypeDto, QualityInspectType>(MemberList.Source);
            CreateMap<QualityProblemLib, QualityProblemLibDto>();
            CreateMap<CreateUpdateQualityProblemLibDto, QualityProblemLib>(MemberList.Source);
            CreateMap<SupplierLevel, SupplierLevelDto>();
            CreateMap<CreateUpdateSupplierLevelDto, SupplierLevel>(MemberList.Source);
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<CreateUpdateWarehouseDto, Warehouse>(MemberList.Source);
            CreateMap<WarehouseArea, WarehouseAreaDto>();
            CreateMap<CreateUpdateWarehouseAreaDto, WarehouseArea>(MemberList.Source);
            CreateMap<WarehouseLocation, WarehouseLocationDto>();
            CreateMap<CreateUpdateWarehouseLocationDto, WarehouseLocation>(MemberList.Source);
            CreateMap<WarehouseType, WarehouseTypeDto>();
            CreateMap<CreateUpdateWarehouseTypeDto, WarehouseType>(MemberList.Source);
            CreateMap<Suppliers.Suppliers, SuppliersDto>();
            CreateMap<CreateUpdateSuppliersDto, Suppliers.Suppliers>(MemberList.Source);
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateUpdateCustomerDto, Customer>(MemberList.Source);
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<CreateUpdateOrderStatusDto, OrderStatus>(MemberList.Source);
            CreateMap<Order, OrderDto>();
            CreateMap<CreateUpdateOrderDto, Order>(MemberList.Source);



        }
    }
}
