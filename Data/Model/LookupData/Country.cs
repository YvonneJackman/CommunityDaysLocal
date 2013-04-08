namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(50)]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}