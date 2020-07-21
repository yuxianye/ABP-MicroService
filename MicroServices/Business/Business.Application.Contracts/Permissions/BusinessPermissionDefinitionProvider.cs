using Business.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Business.Permissions
{
    public class BusinessPermissionDefinitionProvider : PermissionDefinitionProvider
    {

        public override void Define(IPermissionDefinitionContext context)
        {
            var business = context.AddGroup(BusinessPermissions.Business, L("Business"), MultiTenancySides.Tenant);

            var dictionary = business.AddPermission(BusinessPermissions.DataDictionary.Default, L("DataDictionary"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Update, L("Edit"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Delete, L("Delete"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Create, L("Create"));

            var dictionaryDetail = business.AddPermission(BusinessPermissions.DataDictionaryDetail.Default, L("DataDictionary"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Update, L("Edit"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Delete, L("Delete"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Create, L("Create"));

            var organization = business.AddPermission(BusinessPermissions.Organization.Default, L("Organization"));
            organization.AddChild(BusinessPermissions.Organization.Update, L("Edit"));
            organization.AddChild(BusinessPermissions.Organization.Delete, L("Delete"));
            organization.AddChild(BusinessPermissions.Organization.Create, L("Create"));

            var job = business.AddPermission(BusinessPermissions.Job.Default, L("Job"));
            job.AddChild(BusinessPermissions.Job.Update, L("Edit"));
            job.AddChild(BusinessPermissions.Job.Delete, L("Delete"));
            job.AddChild(BusinessPermissions.Job.Create, L("Create"));

            var employee = business.AddPermission(BusinessPermissions.Employee.Default, L("Employee"));
            employee.AddChild(BusinessPermissions.Employee.Update, L("Edit"));
            employee.AddChild(BusinessPermissions.Employee.Delete, L("Delete"));
            employee.AddChild(BusinessPermissions.Employee.Create, L("Create"));





            var enterprisePermission = business.AddPermission(BusinessPermissions.Enterprises.Default, L("Permission:Enterprises"));
            enterprisePermission.AddChild(BusinessPermissions.Enterprises.Create, L("Permission:Create"));
            enterprisePermission.AddChild(BusinessPermissions.Enterprises.Update, L("Permission:Update"));
            enterprisePermission.AddChild(BusinessPermissions.Enterprises.Delete, L("Permission:Delete"));

            var enterpriseAreaPermission = business.AddPermission(BusinessPermissions.EnterpriseAreas.Default, L("Permission:EnterpriseAreas"));
            enterpriseAreaPermission.AddChild(BusinessPermissions.EnterpriseAreas.Create, L("Permission:Create"));
            enterpriseAreaPermission.AddChild(BusinessPermissions.EnterpriseAreas.Update, L("Permission:Update"));
            enterpriseAreaPermission.AddChild(BusinessPermissions.EnterpriseAreas.Delete, L("Permission:Delete"));

            var enterpriseProductionLinePermission = business.AddPermission(BusinessPermissions.EnterpriseProductionLines.Default, L("Permission:EnterpriseProductionLines"));
            enterpriseProductionLinePermission.AddChild(BusinessPermissions.EnterpriseProductionLines.Create, L("Permission:Create"));
            enterpriseProductionLinePermission.AddChild(BusinessPermissions.EnterpriseProductionLines.Update, L("Permission:Update"));
            enterpriseProductionLinePermission.AddChild(BusinessPermissions.EnterpriseProductionLines.Delete, L("Permission:Delete"));

            var enterpriseSitePermission = business.AddPermission(BusinessPermissions.EnterpriseSites.Default, L("Permission:EnterpriseSites"));
            enterpriseSitePermission.AddChild(BusinessPermissions.EnterpriseSites.Create, L("Permission:Create"));
            enterpriseSitePermission.AddChild(BusinessPermissions.EnterpriseSites.Update, L("Permission:Update"));
            enterpriseSitePermission.AddChild(BusinessPermissions.EnterpriseSites.Delete, L("Permission:Delete"));

            var enterpriseWorkCenterPermission = business.AddPermission(BusinessPermissions.EnterpriseWorkCenters.Default, L("Permission:EnterpriseWorkCenters"));
            enterpriseWorkCenterPermission.AddChild(BusinessPermissions.EnterpriseWorkCenters.Create, L("Permission:Create"));
            enterpriseWorkCenterPermission.AddChild(BusinessPermissions.EnterpriseWorkCenters.Update, L("Permission:Update"));
            enterpriseWorkCenterPermission.AddChild(BusinessPermissions.EnterpriseWorkCenters.Delete, L("Permission:Delete"));

            var enterpriseWorkLocationPermission = business.AddPermission(BusinessPermissions.EnterpriseWorkLocations.Default, L("Permission:EnterpriseWorkLocations"));
            enterpriseWorkLocationPermission.AddChild(BusinessPermissions.EnterpriseWorkLocations.Create, L("Permission:Create"));
            enterpriseWorkLocationPermission.AddChild(BusinessPermissions.EnterpriseWorkLocations.Update, L("Permission:Update"));
            enterpriseWorkLocationPermission.AddChild(BusinessPermissions.EnterpriseWorkLocations.Delete, L("Permission:Delete"));

            var equipmentPermission = business.AddPermission(BusinessPermissions.Equipments.Default, L("Permission:Equipments"));
            equipmentPermission.AddChild(BusinessPermissions.Equipments.Create, L("Permission:Create"));
            equipmentPermission.AddChild(BusinessPermissions.Equipments.Update, L("Permission:Update"));
            equipmentPermission.AddChild(BusinessPermissions.Equipments.Delete, L("Permission:Delete"));

            var equipmentInspectionPermission = business.AddPermission(BusinessPermissions.EquipmentInspections.Default, L("Permission:EquipmentInspections"));
            equipmentInspectionPermission.AddChild(BusinessPermissions.EquipmentInspections.Create, L("Permission:Create"));
            equipmentInspectionPermission.AddChild(BusinessPermissions.EquipmentInspections.Update, L("Permission:Update"));
            equipmentInspectionPermission.AddChild(BusinessPermissions.EquipmentInspections.Delete, L("Permission:Delete"));

            var equipmentMaintenancePermission = business.AddPermission(BusinessPermissions.EquipmentMaintenances.Default, L("Permission:EquipmentMaintenances"));
            equipmentMaintenancePermission.AddChild(BusinessPermissions.EquipmentMaintenances.Create, L("Permission:Create"));
            equipmentMaintenancePermission.AddChild(BusinessPermissions.EquipmentMaintenances.Update, L("Permission:Update"));
            equipmentMaintenancePermission.AddChild(BusinessPermissions.EquipmentMaintenances.Delete, L("Permission:Delete"));

            var equipmentSparePartPermission = business.AddPermission(BusinessPermissions.EquipmentSpareParts.Default, L("Permission:EquipmentSpareParts"));
            equipmentSparePartPermission.AddChild(BusinessPermissions.EquipmentSpareParts.Create, L("Permission:Create"));
            equipmentSparePartPermission.AddChild(BusinessPermissions.EquipmentSpareParts.Update, L("Permission:Update"));
            equipmentSparePartPermission.AddChild(BusinessPermissions.EquipmentSpareParts.Delete, L("Permission:Delete"));

            var materialPermission = business.AddPermission(BusinessPermissions.Materials.Default, L("Permission:Materials"));
            materialPermission.AddChild(BusinessPermissions.Materials.Create, L("Permission:Create"));
            materialPermission.AddChild(BusinessPermissions.Materials.Update, L("Permission:Update"));
            materialPermission.AddChild(BusinessPermissions.Materials.Delete, L("Permission:Delete"));

            var productPermission = business.AddPermission(BusinessPermissions.Products.Default, L("Permission:Products"));
            productPermission.AddChild(BusinessPermissions.Products.Create, L("Permission:Create"));
            productPermission.AddChild(BusinessPermissions.Products.Update, L("Permission:Update"));
            productPermission.AddChild(BusinessPermissions.Products.Delete, L("Permission:Delete"));

            var bOMPermission = business.AddPermission(BusinessPermissions.BOMs.Default, L("Permission:Materials"));
            bOMPermission.AddChild(BusinessPermissions.BOMs.Create, L("Permission:Create"));
            bOMPermission.AddChild(BusinessPermissions.BOMs.Update, L("Permission:Update"));
            bOMPermission.AddChild(BusinessPermissions.BOMs.Delete, L("Permission:Delete"));

            var qualityInspectPermission = business.AddPermission(BusinessPermissions.QualityInspects.Default, L("Permission:QualityInspects"));
            qualityInspectPermission.AddChild(BusinessPermissions.QualityInspects.Create, L("Permission:Create"));
            qualityInspectPermission.AddChild(BusinessPermissions.QualityInspects.Update, L("Permission:Update"));
            qualityInspectPermission.AddChild(BusinessPermissions.QualityInspects.Delete, L("Permission:Delete"));

            var qualityInspectTypePermission = business.AddPermission(BusinessPermissions.QualityInspectTypes.Default, L("Permission:QualityInspectTypes"));
            qualityInspectTypePermission.AddChild(BusinessPermissions.QualityInspectTypes.Create, L("Permission:Create"));
            qualityInspectTypePermission.AddChild(BusinessPermissions.QualityInspectTypes.Update, L("Permission:Update"));
            qualityInspectTypePermission.AddChild(BusinessPermissions.QualityInspectTypes.Delete, L("Permission:Delete"));

            var qualityProblemLibPermission = business.AddPermission(BusinessPermissions.QualityProblemLibs.Default, L("Permission:QualityProblemLibs"));
            qualityProblemLibPermission.AddChild(BusinessPermissions.QualityProblemLibs.Create, L("Permission:Create"));
            qualityProblemLibPermission.AddChild(BusinessPermissions.QualityProblemLibs.Update, L("Permission:Update"));
            qualityProblemLibPermission.AddChild(BusinessPermissions.QualityProblemLibs.Delete, L("Permission:Delete"));

            var suppliersPermission = business.AddPermission(BusinessPermissions.Suppliers.Default, L("Permission:Suppliers"));
            suppliersPermission.AddChild(BusinessPermissions.Suppliers.Create, L("Permission:Create"));
            suppliersPermission.AddChild(BusinessPermissions.Suppliers.Update, L("Permission:Update"));
            suppliersPermission.AddChild(BusinessPermissions.Suppliers.Delete, L("Permission:Delete"));

            var warehousePermission = business.AddPermission(BusinessPermissions.Warehouses.Default, L("Permission:Warehouses"));
            warehousePermission.AddChild(BusinessPermissions.Warehouses.Create, L("Permission:Create"));
            warehousePermission.AddChild(BusinessPermissions.Warehouses.Update, L("Permission:Update"));
            warehousePermission.AddChild(BusinessPermissions.Warehouses.Delete, L("Permission:Delete"));

            var warehouseAreaPermission = business.AddPermission(BusinessPermissions.WarehouseAreas.Default, L("Permission:WarehouseAreas"));
            warehouseAreaPermission.AddChild(BusinessPermissions.WarehouseAreas.Create, L("Permission:Create"));
            warehouseAreaPermission.AddChild(BusinessPermissions.WarehouseAreas.Update, L("Permission:Update"));
            warehouseAreaPermission.AddChild(BusinessPermissions.WarehouseAreas.Delete, L("Permission:Delete"));

            var WarehouseLocationPermission = business.AddPermission(BusinessPermissions.WarehouseLocations.Default, L("Permission:WarehouseLocations"));
            WarehouseLocationPermission.AddChild(BusinessPermissions.WarehouseLocations.Create, L("Permission:Create"));
            WarehouseLocationPermission.AddChild(BusinessPermissions.WarehouseLocations.Update, L("Permission:Update"));
            WarehouseLocationPermission.AddChild(BusinessPermissions.WarehouseLocations.Delete, L("Permission:Delete"));

            var warehouseTypePermission = business.AddPermission(BusinessPermissions.WarehouseTypes.Default, L("Permission:WarehouseTypes"));
            warehouseTypePermission.AddChild(BusinessPermissions.WarehouseTypes.Create, L("Permission:Create"));
            warehouseTypePermission.AddChild(BusinessPermissions.WarehouseTypes.Update, L("Permission:Update"));
            warehouseTypePermission.AddChild(BusinessPermissions.WarehouseTypes.Delete, L("Permission:Delete"));


            var customerPermission = business.AddPermission(BusinessPermissions.Customers.Default, L("Permission:Customers"));
            customerPermission.AddChild(BusinessPermissions.Customers.Create, L("Permission:Create"));
            customerPermission.AddChild(BusinessPermissions.Customers.Update, L("Permission:Update"));
            customerPermission.AddChild(BusinessPermissions.Customers.Delete, L("Permission:Delete"));

            var orderStatusPermission = business.AddPermission(BusinessPermissions.Orders.Default, L("Permission:Orders"));
            orderStatusPermission.AddChild(BusinessPermissions.Orders.Create, L("Permission:Create"));
            orderStatusPermission.AddChild(BusinessPermissions.Orders.Update, L("Permission:Update"));
            orderStatusPermission.AddChild(BusinessPermissions.Orders.Delete, L("Permission:Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BusinessResource>(name);
        }
    }
}
