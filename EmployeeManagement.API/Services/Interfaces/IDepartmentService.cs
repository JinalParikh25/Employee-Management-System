using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponseDto>> GetDepartmentsAsync();
        Task<DepartmentResponseDto> GetDepartmentAsync(int id);
        Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentsDTos dto);
        Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentsDTOs dto);
        Task<bool> DeleteDepartmentAsync(int id);

    }
}
