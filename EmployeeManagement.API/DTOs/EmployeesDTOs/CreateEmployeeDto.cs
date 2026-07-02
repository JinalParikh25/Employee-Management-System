using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.DTOs.EmployeesDTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
