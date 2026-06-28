using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repositories.Interfaces;
using EmployeeManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentsDto dto)
        {
            Department department = new Department
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,
                UpdatedAt = null
            };

            await _departmentRepository.AddAsync(department);

            await _departmentRepository.SaveChangesAsync();

            return new DepartmentResponseDto
            { 
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
           var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
                return false;

            department.IsDeleted = true;
            department.UpdatedAt = DateTime.UtcNow;

            await _departmentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<DepartmentResponseDto> GetDepartmentAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                return null;

            return new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };
        }

        public async Task<List<DepartmentResponseDto>> GetDepartmentsAsync()
        {
           var departments = await _departmentRepository.GetAllAsync();

           return departments.Select(d => new DepartmentResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).ToList();
        }

        public async Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentsDTOs dto)
        {
          var department = await _departmentRepository.GetByIdAsync(id);

            if(department == null)
                return false;

            department.Name = dto.Name;
            department.Description = dto.Description;
            department.UpdatedAt = DateTime.UtcNow;
            await _departmentRepository.SaveChangesAsync();

            return true;
        }
    }
}
