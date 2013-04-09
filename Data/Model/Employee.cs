namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employee
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Display(Name = "Login")]
        public string NTLogin { get; set; }

        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Contact Number")]
        public string EmployeeContactNumber { get; set; }

        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Payroll Number")]
        public string EmployeePayrollNumber { get; set; }

        [Display(Name = "Manager Email")]
        public string ManagerEmail { get; set; }

        [Display(Name = "Manager First Name")]
        public string ManagerFirstName { get; set; }

        [Display(Name = "Manager Last Name")]
        public string ManagerLastName { get; set; }

        [Display(Name = "New Project Notification")]
        public bool SendNewProjectEmailFlag { get; set; }

        [Display(Name = "New Project Distance")]
        public int NewProjectDistance { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Directorate")]
        public int DirectorateId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Cost Centre")]
        public string CostCentre { get; set; }

        public virtual Country Country { get; set; }

        public virtual Location Location { get; set; }

        public virtual Directorate Directorate { get; set; }

        public virtual Department Department { get; set; }
    }
}
