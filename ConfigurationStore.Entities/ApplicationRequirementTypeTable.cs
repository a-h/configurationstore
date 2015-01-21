using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ConfigurationStore.Entities
{
    public class ApplicationRequirementTypeTable
    {
        public int ApplicationRequirementTypeId { get; set; }

        [Required(AllowEmptyStrings = false), StringLength(250)]
        public string Name { get; set; }
    }
}
