using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ApplicationTable
    {
        public int ApplicationId { get; set; }

        public string Name { get; set; }

        public virtual IList<SystemTable> Systems { get; set; }

        public virtual IList<ApplicationRequirementTable> Requirements { get; set; }
    }
}
