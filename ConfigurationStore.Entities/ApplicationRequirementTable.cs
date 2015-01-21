using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ApplicationRequirementTable
    {
        public int ApplicationRequirementId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ApplicationRequirementTypeId")]
        public virtual ApplicationRequirementTypeTable RequirementType { get; set; }

        public int ApplicationRequirementTypeId { get; set; }

        public virtual IList<ApplicationRequirementInstanceTable> Instances { get; set; }
    }
}
