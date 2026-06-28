using EmployeeManagement.API.DTOs.EmployeesDTOs;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repositories.Interfaces;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                JobTitle = e.JobTitle,
                JoiningDate = e.JoiningDate,
                DepartmentId = e.DepartmentId
            }).ToList();
        }
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if(employee == null)
                return null;


            return new EmployeeResponseDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                JobTitle = employee.JobTitle,
                JoiningDate = employee.JoiningDate,
                DepartmentId = employee.DepartmentId
            };
        }

        public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                JobTitle = dto.JobTitle,
                JoiningDate = dto.JoiningDate,
                DepartmentId = dto.DepartmentId
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.saveChangesAsync();
            return new EmployeeResponseDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                JobTitle = employee.JobTitle,
                JoiningDate = employee.JoiningDate,
                DepartmentId = employee.DepartmentId
            };
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return false;

            employee.IsDeleted = true;
            employee.UpdatedAt = DateTime.UtcNow;

            await _employeeRepository.saveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return false;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.DepartmentId = dto.DepartmentId;
            employee.JoiningDate = dto.JoiningDate;
            employee.JobTitle = dto.JobTitle;
            employee.UpdatedAt = DateTime.UtcNow;
            
            await _employeeRepository.saveChangesAsync();
            return true;
        }
    }
}
