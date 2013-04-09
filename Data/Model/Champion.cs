namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Champion
    {
        [Key]
        public int ChampionId { get; set; }

        [Display(Name = "First Name")]
        public string ChampionFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ChampionLastName { get; set; }

        [Display(Name = "Contact Number")]
        public string ChampionContactNumber { get; set; }

        [Display(Name = "Email")]
        public string ChampionEmail { get; set; }
    }
}