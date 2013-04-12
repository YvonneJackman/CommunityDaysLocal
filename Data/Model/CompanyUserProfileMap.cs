namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyUserProfileMap
    {
        [Key]
        public int CompanyUserProfileMapId { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("UserProfile"), Column(Order = 0)]
        public int UserId { get; set; }

        public virtual Company Company { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}