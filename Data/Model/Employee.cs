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
        public int EmployeeId { get; set; }

        [Display(Name = "Login")]
        public string NTLogin { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Department")]
        public string EmployeeDepartment { get; set; }

        [Display(Name = "Contact Number")]
        public string EmployeeContactNumber { get; set; }

        [Display(Name = "Postcode")]
        public string EmployeeWorkPostcode { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Directorate")]
        public int DirectorateId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Location Location { get; set; }

        public virtual Directorate Directorate { get; set; }

        public virtual Department Department { get; set; }
    }
}
