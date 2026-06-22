using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task AddAsync(Department department);
        Task SaveChangesAsync();
        //Task<IActionResult> UpdateDepartment(int id, CreateDepartmentsDTos dto);
        //Task<IActionResult> DeleteDepartment(int id);
    }
}
