using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Permissions
{
    public static class BusinessPermissions
    {
        public const string Business = "Business";

        public static class AuditLogging
        {
            public const string Default = Business + ".AuditLogging";
        }

        public static class DataDictionary
        {
            public const string Default = Business + ".DataDictionary";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class DataDictionaryDetail
        {
            public const string Default = Business + ".DataDictionaryDetail";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Organization
        {
            public const string Default = Business + ".Organization";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Job
        {
            public const string Default = Business + ".Job";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Employee
        {
            public const string Default = Business + ".Employee";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        public class Enterprises
        {
            public const string Default = Business + ".Enterprises";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class EnterpriseAreas
        {
            public const string Default = Business + ".EnterpriseAreas";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class EnterpriseProductionLines
        {
            public const string Default = Business + ".EnterpriseProductionLines";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class EnterpriseSites
        {
            public const string Default = Business + ".EnterpriseSites";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class EnterpriseWorkCenters
        {
            public const string Default = Business + ".EnterpriseWorkCenters";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class EnterpriseWorkLocations
        {
            public const string Default = Business + ".EnterpriseWorkLocations";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }



        public class Equipments
        {
            public const string Default = Business + ".Equipments";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class EquipmentInspections
        {
            public const string Default = Business + ".EquipmentInspections";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class EquipmentMaintenances
        {
            public const string Default = Business + ".EquipmentMaintenances";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class EquipmentSpareParts
        {
            public const string Default = Business + ".EquipmentSpareParts";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }


        public class BOMs
        {
            public const string Default = Business + ".BOMs";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class Materials
        {
            public const string Default = Business + ".Materials";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class Products
        {
            public const string Default = Business + ".Products";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }



        public class QualityInspects
        {
            public const string Default = Business + ".QualityInspects";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class QualityInspectTypes
        {
            public const string Default = Business + ".QualityInspectTypes";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class QualityProblemLibs
        {
            public const string Default = Business + ".QualityProblemLibs";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Suppliers
        {
            public const string Default = Business + ".Suppliers";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }


        public class Warehouses
        {
            public const string Default = Business + ".Warehouses";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class WarehouseAreas
        {
            public const string Default = Business + ".WarehouseAreas";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class WarehouseLocations
        {
            public const string Default = Business + ".WarehouseLocations";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class WarehouseTypes
        {
            public const string Default = Business + ".WarehouseTypes";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }



        public class Customers
        {
            public const string Default = Business + ".Customers";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }


        public class Orders
        {
            public const string Default = Business + ".Orders";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }




    }
}
