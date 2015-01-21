using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class EnvironmentTable
    {
        public int EnvironmentId { get; set; }

        [ForeignKey("SystemId")]
        public virtual SystemTable System { get; set; }
        
        public int SystemId { get; set; }

        public string Name { get; set; }

        public virtual IList<ApplicationTable> Applications { get; set; }
    }
}
