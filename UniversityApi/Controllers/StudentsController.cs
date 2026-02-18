using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.DTOs;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public StudentsController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            return await _context.Students
                .Select(s => new StudentDto
                {
                    StudentID = s.StudentID,
                    FirstMidName = s.FirstMidName,
                    LastName = s.LastName,
                    EnrollmentDate = s.EnrollmentDate
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return new StudentDto
            {
                StudentID = student.StudentID,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                FirstMidName = dto.FirstMidName,
                LastName = dto.LastName,
                EnrollmentDate = dto.EnrollmentDate
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var result = new StudentDto
            {
                StudentID = student.StudentID,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentUpdateDto dto)
        {
            if (id != dto.StudentID) return BadRequest();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.FirstMidName = dto.FirstMidName;
            student.LastName = dto.LastName;
            student.EnrollmentDate = dto.EnrollmentDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
