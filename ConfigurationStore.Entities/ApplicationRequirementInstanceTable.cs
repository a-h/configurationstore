using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ApplicationRequirementInstanceTable
    {
        public int ApplicationRequirementInstanceId { get; set; }

        [ForeignKey("ApplicationRequirementId")]
        public virtual ApplicationRequirementTable ApplicationRequirement { get; set; }

        public int ApplicationRequirementId { get; set; }

        [ForeignKey("EnvironmentId")]
        public virtual EnvironmentTable Environment { get; set; }

        public int EnvironmentId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Value { get; set; }
    }
}
