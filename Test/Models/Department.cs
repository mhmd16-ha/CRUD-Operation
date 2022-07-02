using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("Department",Schema ="HR")]
    public class Department
    {
        [Key]
        [Display(Name ="ID")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [Column (TypeName ="varchar(200)")]
        public string? DepartmentName { get; set; }
    }
}
