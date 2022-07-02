using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("Employee",Schema ="HR")]
    public class Employee
    {
        [Key]
        [Display(Name ="ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        [Column(TypeName = "varchar(200)")]
        public string EmployeeName { get; set; }=string.Empty;
        [Display(Name = "Image User")]
        [Column(TypeName = "varchar(250)")]
        public string? Image { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Salary")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salary { get; set; }
        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        [Required]
        [Display(Name = "National Id")]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName="varchar(14)")]
        public string NationalId { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
