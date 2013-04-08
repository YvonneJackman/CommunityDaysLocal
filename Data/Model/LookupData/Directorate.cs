namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Directorate
    {
        [Key]
        public int DirectorateId { get; set; }

        [StringLength(50)]
        [Display(Name = "Directorate Name")]
        public string DirectorateName { get; set; }

        [StringLength(50)]
        [Display(Name = "Director")]
        public string Director { get; set; }
    }
}