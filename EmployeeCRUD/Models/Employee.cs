using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        [Required]
        [DisplayName("Date of birth")]
        public string EmployeeDOB { get; set; } = Convert.ToString(DateOnly.FromDateTime(DateTime.Today));
        [Required]
        [DisplayName("Function")]
        public string EmployeeFunction { get; set; }
        [DisplayName("Location")]
        public string EmployeeLocation { get; set; }
        [Required]
        [DisplayName("Role")]
        public string EmployeeRole { get; set; }
    }
}
