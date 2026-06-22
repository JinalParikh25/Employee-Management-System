using EmployeeManagement.API.Data;
using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _context.Departments
                                .Where(d => !d.IsDeleted)
                                .Select(d => new DepartmentResponseDto
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Description = d.Description
                                }).ToListAsync();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponseDto>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if(department == null) {
                return NotFound();
            }

            DepartmentResponseDto departmentResponseDto = new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return departmentResponseDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentsDTos dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,

            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            var departmentDto = new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return CreatedAtAction(nameof(GetDepartment), new { department.Id }, departmentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            department.IsDeleted = true;
            department.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentsDTOs dto)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (department == null)
            {
                return NotFound();
            }
            department.Name = dto.Name;
            department.Description = dto.Description;
            department.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
