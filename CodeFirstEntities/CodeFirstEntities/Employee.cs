using System.ComponentModel.DataAnnotations;

namespace CodeFirstEntities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is Mandatory")]
        [StringLength(100, ErrorMessage = "Employee name must be less than 100 characters.")]
        public string Name { get; set; }
        

        public int Code { get; set; }
        public System.DateTime  StartDate { get; set; }

        //public bool regenerate { get; set; }

    }
}
