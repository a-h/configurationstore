using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ConfigurationItemTable
    {
        public int ConfigurationItemId { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual ApplicationTable Application { get; set; }

        public int ApplicationId { get; set; }

        public string Name { get; set; }

        public virtual IList<ConfigurationItemInstanceTable> Instances { get; set; }
    }
}
