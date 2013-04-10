namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Approved")]
        public bool CompanyApprovedFlag { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [StringLength(10)]
        [Display(Name = "Charity Number")]
        public string CharityNumber { get; set; }

        [ForeignKey("OrganisationType")]
        [Display(Name = "OrganisationType")]
        public int OrganisationTypeId { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Contact Name")]
        public string CompanyContactName { get; set; }

        [StringLength(50)]
        [Display(Name = "Contact Phone")]
        public string CompanyContactPhone { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Contact Email")]
        public string CompanyContactEmail { get; set; }
        
        [StringLength(1000)]
        [Display(Name = "Details")]
        public string CompanyDetails { get; set; }
        
        [StringLength(200)]
        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        
        [StringLength(8)]
        [Display(Name = "Postcode")]
        public string CompanyPostcode { get; set; }

        [Display(Name = "Opt Out Of Reminder Emails")]
        public bool OptOutOfReminderEmails { get; set; }

        public virtual OrganisationType OrganisationType { get; set; }
    }
}