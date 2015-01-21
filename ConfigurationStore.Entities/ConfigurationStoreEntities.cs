using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationStore.Entities
{
    public class ConfigurationStoreEntities : DbContext, IConfigurationStoreEntities
    {
        public IDbSet<SystemTable> Systems { get; set; }
        public IDbSet<EnvironmentTable> Environments { get; set; }
        public IDbSet<ApplicationTable> Applications { get; set; }
        public IDbSet<ConfigurationItemTable> ConfigurationItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRequirementInstanceTable>()
                .ToTable("ApplicationRequirementInstance")
                .HasKey(t => t.ApplicationRequirementInstanceId);

            modelBuilder.Entity<ApplicationRequirementTable>()
                .ToTable("ApplicationRequirement")
                .HasKey(t => t.ApplicationRequirementId);

            modelBuilder.Entity<ApplicationRequirementTypeTable>()
                .ToTable("ApplicationRequirementType")
                .HasKey(t => t.ApplicationRequirementTypeId);

            modelBuilder.Entity<ApplicationTable>()
                .ToTable("Application")
                .HasKey(t => t.ApplicationId);

            modelBuilder.Entity<ConfigurationItemInstanceTable>()
                .ToTable("ConfigurationItemInstance")
                .HasKey(t => t.ConfigurationItemInstanceId);

            modelBuilder.Entity<ConfigurationItemTable>()
                .ToTable("ConfigurationItem")
                .HasKey(t => t.ConfigurationItemId);

            modelBuilder.Entity<EnvironmentTable>()
                .ToTable("Environment")
                .HasKey(t => t.EnvironmentId);

            modelBuilder.Entity<SystemTable>()
                .ToTable("System")
                .HasKey(t => t.SystemId);
        }
    }
}
