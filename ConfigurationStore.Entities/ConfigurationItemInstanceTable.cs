using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ConfigurationItemInstanceTable
    {
        public int ConfigurationItemInstanceId { get; set; }

        [ForeignKey("ConfigurationItemId")]
        public virtual ConfigurationItemTable ConfigurationItem { get; set; }

        public int ConfigurationItemId { get; set; }

        [ForeignKey("EnvironmentId")]
        public virtual EnvironmentTable Environment { get; set; }

        public int EnvironmentId { get; set; }

        [Required(AllowEmptyStrings=true)]
        public string Value { get; set; }
    }
}
