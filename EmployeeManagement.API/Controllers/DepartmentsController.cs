using EmployeeManagement.API.DTOs.DepartmentsDTOs;
using EmployeeManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departmentsdto = await _departmentService.GetDepartmentsAsync();

            return Ok(departmentsdto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentResponseDto>> GetDepartment(int id)
        {
            var departmentResponseDto = await _departmentService.GetDepartmentAsync(id);

            if (departmentResponseDto == null)
                return NotFound();

            return Ok(departmentResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentsDto dto)
        {
          var departmentResponseDto = await _departmentService.CreateDepartmentAsync(dto);
            return CreatedAtAction(nameof(GetDepartment), new { id = departmentResponseDto.Id }, departmentResponseDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
           var deleted = await _departmentService.DeleteDepartmentAsync(id);

            if (!deleted)
                return NotFound();
            return NoContent();
        } 

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentsDTOs dto)
        {
         var updated = await _departmentService.UpdateDepartmentAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }
    }
}
