using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("Employee",Schema ="HR")]
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
