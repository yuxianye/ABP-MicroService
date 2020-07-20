using Business.BaseData;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Business.Orders;
using Business.Customers;
using Business.Warehouses;
using Business.Suppliers;
using Business.Qualities;
using Business.Public;
using Business.Materials;
using Business.Equipments;
using Business.Enterprises;

namespace Business.EntityFrameworkCore
{
    public static class BusinessDbContextModelCreatingExtensions
    {
        public static void ConfigureBusiness(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<DataDictionary>(b =>
            {
                b.ToTable("base_dict");

                b.ConfigureConcurrencyStamp();
                b.ConfigureExtraProperties();
                b.ConfigureAudited();

                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.Description).HasMaxLength(BusinessConsts.MaxNotesLength);
                b.Property(x => x.IsDeleted).HasDefaultValue(false);

                b.HasIndex(q => q.Name);
            });

            builder.Entity<DataDictionaryDetail>(b =>
            {
                b.ToTable("base_dict_details");

                b.ConfigureConcurrencyStamp();
                b.ConfigureExtraProperties();
                b.ConfigureAudited();

                b.Property(x => x.Label).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.Value).IsRequired().HasMaxLength(BusinessConsts.MaxNotesLength);
                b.Property(x => x.IsDeleted).HasDefaultValue(false);

                b.HasIndex(q => q.Pid);
            });

            builder.Entity<Organization>(b =>
            {
                b.ToTable("base_orgs");

                b.ConfigureConcurrencyStamp();
                b.ConfigureExtraProperties();
                b.ConfigureAudited();
                b.ConfigureSoftDelete();

                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.FullName).IsRequired().HasMaxLength(BusinessConsts.MaxFullNameLength);
                b.Property(x => x.CascadeId).HasMaxLength(BusinessConsts.MaxNotesLength);
                b.Property(x => x.Enabled).HasDefaultValue(false);

                b.HasIndex(q => q.Pid);
            });

            builder.Entity<Employee>(b =>
            {
                b.ToTable("base_employees");
                b.ConfigureConcurrencyStamp();
                b.ConfigureExtraProperties();
                b.ConfigureAudited();
                b.ConfigureSoftDelete();

                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.Email).IsRequired().HasMaxLength(BusinessConsts.MaxNotesLength);

                b.HasIndex(q => q.UserId);
            });

            builder.Entity<Job>(b =>
            {
                b.ToTable("base_jobs");
                b.ConfigureConcurrencyStamp();
                b.ConfigureExtraProperties();
                b.ConfigureAudited();
                b.ConfigureSoftDelete();

                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.MaxNameLength);
                b.Property(x => x.Description).HasMaxLength(BusinessConsts.MaxNotesLength);
            });

            builder.Entity<EmployeeJob>(b =>
            {
                b.ToTable("base_employee_jobs");
                b.HasKey(k => k.EmployeeId);
            });



            builder.Entity<Enterprise>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Enterprises", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Address).HasMaxLength(BusinessConsts.AddressLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);

                /* Configure more properties here */
            });

            builder.Entity<EnterpriseArea>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EnterpriseAreas", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Manager).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EnterpriseProductionLine>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EnterpriseProductionLines", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Manager).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EnterpriseSite>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EnterpriseSites", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Address).HasMaxLength(BusinessConsts.AddressLength);
                b.Property(x => x.Manager).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EnterpriseWorkCenter>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EnterpriseWorkCenters", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Manager).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EnterpriseWorkLocation>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EnterpriseWorkLocations", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentType>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentTypes", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentStatus>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentStatuses", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentSparePartType>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentSparePartTypes", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentSparePart>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentSpareParts", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentMaintenanceResult>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentMaintenanceResults", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentMaintenance>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentMaintenances", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Problem).IsRequired().HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Cause).IsRequired().HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Solution).IsRequired().HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Consumable).IsRequired().HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.ResponsiblePerson).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentInspectionResult>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentInspectionResults", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentInspection>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentInspections", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.InspectPerson).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Problem).HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Cause).HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Solution).HasMaxLength(BusinessConsts.StringLength256);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<EquipmentBrand>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "EquipmentBrands", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<Equipment>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Equipment", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Specification).IsRequired().HasMaxLength(BusinessConsts.StringLength64);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });


            builder.Entity<Material>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Materials", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Specification).HasMaxLength(BusinessConsts.StringLength64);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<Product>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Products", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Specification).IsRequired().HasMaxLength(BusinessConsts.StringLength64);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<ProductType>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "ProductTypes", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<BOM>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "BOMs", BusinessConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Version).IsRequired().HasMaxLength(BusinessConsts.StringLength64);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                /* Configure more properties here */
            });

            builder.Entity<Unit>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Units", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<QualityInspect>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "QualityInspects", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.Property(x => x.InspectPerson).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<QualityInspectResult>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "QualityInspectResults", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<QualityInspectType>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "QualityInspectTypes", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<QualityProblemLib>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "QualityProblemLibs", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<SupplierLevel>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "SupplierLevels", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<Suppliers.Suppliers>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Suppliers", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Contact).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Fax).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Address).HasMaxLength(BusinessConsts.AddressLength);
                b.Property(x => x.Email).HasMaxLength(BusinessConsts.EmailLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<Warehouse>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Warehouses", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Manager).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<WarehouseArea>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "WarehouseAreas", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<WarehouseLocation>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "WarehouseLocations", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<WarehouseType>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "WarehouseTypes", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });



            builder.Entity<Customer>(b =>
            {

                b.ToTable(BusinessConsts.DbTablePrefix + "Customers", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Address).HasMaxLength(BusinessConsts.AddressLength);
                b.Property(x => x.Contact).HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Phone).HasMaxLength(BusinessConsts.PhoneLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<OrderStatus>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "OrderStatuses", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Name).IsUnique(true);
                b.Property(x => x.Name).IsRequired().HasMaxLength(BusinessConsts.NameLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<Order>(b =>
            {
                b.ToTable(BusinessConsts.DbTablePrefix + "Orders", BusinessConsts.DbSchema);
                b.HasIndex(x => x.Code).IsUnique(true);
                b.Property(x => x.Code).IsRequired().HasMaxLength(BusinessConsts.CodeLength);
                b.Property(x => x.Remark).HasMaxLength(BusinessConsts.RemarkLength);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });








        }
    }
}
