using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationStore.Entities
{
    public interface IConfigurationStoreEntities
    {
        IDbSet<SystemTable> Systems { get; set; }
        IDbSet<EnvironmentTable> Environments { get; set; }
        IDbSet<ApplicationTable> Applications { get; set; }
        IDbSet<ConfigurationItemTable> ConfigurationItems { get; set; }
    }
}
