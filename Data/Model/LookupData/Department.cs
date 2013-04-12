namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        //[ForeignKey("Directorate")] todo
        public int DirectorateId { get; set; }

        public virtual Directorate Directorate { get; set; }
    }
}
