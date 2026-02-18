namespace UniversityApi.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstMidName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }

        // Navigation property
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
