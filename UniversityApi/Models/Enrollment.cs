namespace UniversityApi.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        // Foreign keys
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public string? Grade { get; set; }

        // Navigation properties
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
