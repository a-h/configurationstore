using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class SystemTable
    {
        public int SystemId { get; set; }

        public string Name { get; set; }

        public virtual IList<EnvironmentTable> Environments { get; set; }

        public virtual IList<ApplicationTable> Applications { get; set; }
    }
}
