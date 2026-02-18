using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.DTOs;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityContext _context;

        public CoursesController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            return await _context.Courses
                .Select(c => new CourseDto
                {
                    CourseID = c.CourseID,
                    Title = c.Title,
                    Credits = c.Credits
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return new CourseDto
            {
                CourseID = course.CourseID,
                Title = course.Title,
                Credits = course.Credits
            };
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseCreateDto dto)
        {
            var course = new Course
            {
                CourseID = dto.CourseID,
                Title = dto.Title,
                Credits = dto.Credits
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var result = new CourseDto
            {
                CourseID = course.CourseID,
                Title = course.Title,
                Credits = course.Credits
            };

            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseUpdateDto dto)
        {
            if (id != dto.CourseID) return BadRequest();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            // Update only the allowed fields
            course.Title = dto.Title;
            course.Credits = dto.Credits;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
