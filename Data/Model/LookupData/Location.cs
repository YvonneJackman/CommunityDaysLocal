namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Location
    {   
        [Key]
        public int LocationId { get; set; }

        [StringLength(50)]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [StringLength(8)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        //[ForeignKey("Country")] todo
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
