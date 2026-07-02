using EmployeeManagement.API.Data;
using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace EmployeeManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.OrderBy(d => d.Id).ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }
        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsDepartmentNameExistsAsync(Department department)
        {
            return await _context.Departments.AnyAsync(d => d.Name == department.Name);
        }

        public async Task<bool> HasActiveEmployeesAsync(int departmentId)
        {
            return await _context.Employees.AnyAsync(e => e.DepartmentId == departmentId);
        }
    }
}
