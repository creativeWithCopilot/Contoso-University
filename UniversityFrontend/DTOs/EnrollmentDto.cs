namespace UniversityFrontend.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string? Grade { get; set; }
    }

    public class EnrollmentCreateDto
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string? Grade { get; set; }
    }

    public class EnrollmentUpdateDto 
    { 
        public int EnrollmentID { get; set; } 
        public int StudentID { get; set; } 
        public int CourseID { get; set; } 
        public string? Grade { get; set; } 
    }
}
