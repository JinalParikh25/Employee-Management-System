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
            return await _context.Departments.Where(d => !d.IsDeleted).ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        }
        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            
        }

        public async Task SaveChangesAsync()
        { 
            await _context.SaveChangesAsync();
        }
       
    }
}
