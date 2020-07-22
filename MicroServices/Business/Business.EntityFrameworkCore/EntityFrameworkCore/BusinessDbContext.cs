using Business.BaseData;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Business.Enterprises;
using Business.Equipments;
using Business.Materials;
using Business.Qualities;
using Business.Suppliers;
using Business.Warehouses;
using Business.Customers;
using Business.Orders;

namespace Business.EntityFrameworkCore
{
    [ConnectionStringName("Business")]
    public class BusinessDbContext : AbpDbContext<BusinessDbContext>
    {
        public DbSet<DataDictionary> DataDictionaries { get; set; }

        public DbSet<DataDictionaryDetail> DataDictionaryDetails { get; set; }

        public DbSet<Organization> organizations { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Job> jobs { get; set; }

        public DbSet<EmployeeJob> employeeJobs { get; set; }



        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseArea> EnterpriseAreas { get; set; }
        public DbSet<EnterpriseProductionLine> EnterpriseProductionLines { get; set; }
        public DbSet<EnterpriseSite> EnterpriseSites { get; set; }
        public DbSet<EnterpriseWorkCenter> EnterpriseWorkCenters { get; set; }
        public DbSet<EnterpriseWorkLocation> EnterpriseWorkLocations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentInspection> EquipmentInspections { get; set; }
        public DbSet<EquipmentMaintenance> EquipmentMaintenances { get; set; }
        public DbSet<EquipmentSparePart> EquipmentSpareParts { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BOM> BOMs { get; set; }
        public DbSet<QualityInspect> QualityInspects { get; set; }
        public DbSet<QualityProblemLib> QualityProblemLibs { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseArea> WarehouseAreas { get; set; }
        public DbSet<WarehouseLocation> WarehouseLocations { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }
        public DbSet<Suppliers.Suppliers> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }









        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureBusiness();
        }
    }
}
