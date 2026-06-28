using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.DTOs.DepartmentsDTOs
{
    public class CreateDepartmentsDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
