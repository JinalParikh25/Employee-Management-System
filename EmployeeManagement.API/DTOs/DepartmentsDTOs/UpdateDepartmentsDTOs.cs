using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.DTOs.DepartmentsDTOs
{
    public class UpdateDepartmentsDTOs
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}