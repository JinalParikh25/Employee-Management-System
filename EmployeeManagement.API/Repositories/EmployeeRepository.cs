using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; // Add this at the top if not present

namespace EmployeeManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _applicationDbContext.Employees.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Employees.FindAsync(id);
        }
        public async Task AddAsync(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
        }
        public async Task saveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<bool> IsEmailExistsAsync(string email) 
        {
            return await _applicationDbContext.Employees.AnyAsync(e => e.Email == email);
        }
        //public async Task<bool> IsEmailExistsAsync(string email)
        //{
        //    return await _applicationDbContext.Employees.AnyAsync(e => e.Email == email);
        //}
    }
}
