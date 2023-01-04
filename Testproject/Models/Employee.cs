using System.ComponentModel.DataAnnotations;

namespace Testproject.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id can't be empty")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Designation can't be empty")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "salary can't be empty")]
        public int salary { get; set; }
        [Required(ErrorMessage = "email can't be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile can't be empty")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "qualification can't be empty")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "manager can't be empty")]

        public string Manager { get; set; }
        

    }
}
