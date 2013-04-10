namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrganisationType
    {
        [Key]
        public int OrganisationTypeId { get; set; }

        [StringLength(50)]
        [Display(Name = "Organisation Type")]
        public string OrganisationTypeName { get; set; }
    }
}
