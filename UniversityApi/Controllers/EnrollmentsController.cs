using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.DTOs;
using UniversityApi.Models;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : ControllerBase
{
    private readonly UniversityContext _context;

    public EnrollmentsController(UniversityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetEnrollments()
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .Select(e => new EnrollmentDto
            {
                EnrollmentID = e.EnrollmentID,
                CourseID = e.CourseID,
                CourseTitle = e.Course.Title,
                StudentID = e.StudentID,
                StudentName = e.Student.FirstMidName + " " + e.Student.LastName,
                Grade = e.Grade
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnrollmentDto>> GetEnrollment(int id)
    {
        var enrollment = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentID == id);

        if (enrollment == null) return NotFound();

        return new EnrollmentDto
        {
            EnrollmentID = enrollment.EnrollmentID,
            CourseID = enrollment.CourseID,
            CourseTitle = enrollment.Course.Title,
            StudentID = enrollment.StudentID,
            StudentName = enrollment.Student.FirstMidName + " " + enrollment.Student.LastName,
            Grade = enrollment.Grade
        };
    }

    [HttpPost]
    public async Task<ActionResult<EnrollmentDto>> PostEnrollment(EnrollmentCreateDto dto)
    {
        var enrollment = new Enrollment
        {
            StudentID = dto.StudentID,
            CourseID = dto.CourseID,
            Grade = dto.Grade
        };

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        // Project back into EnrollmentDto for response
        var result = new EnrollmentDto
        {
            EnrollmentID = enrollment.EnrollmentID,
            StudentID = enrollment.StudentID,
            CourseID = enrollment.CourseID,
            Grade = enrollment.Grade,
            StudentName = (await _context.Students.FindAsync(enrollment.StudentID))?.FirstMidName
                        + " " + (await _context.Students.FindAsync(enrollment.StudentID))?.LastName,
            CourseTitle = (await _context.Courses.FindAsync(enrollment.CourseID))?.Title
        };

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentID }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEnrollment(int id, EnrollmentUpdateDto dto)
    {
        if (id != dto.EnrollmentID) return BadRequest();

        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null) return NotFound();

        // Update only the allowed fields
        enrollment.StudentID = dto.StudentID;
        enrollment.CourseID = dto.CourseID;
        enrollment.Grade = dto.Grade;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null) return NotFound();

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
