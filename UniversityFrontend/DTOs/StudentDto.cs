namespace UniversityFrontend.DTOs
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public class StudentCreateDto 
    { 
        public string FirstMidName { get; set; } 
        public string LastName { get; set; } 
        public DateTime EnrollmentDate { get; set; }
    }

    public class StudentUpdateDto 
    { 
        public int StudentID { get; set; } 
        public string FirstMidName { get; set; } 
        public string LastName { get; set; } 
        public DateTime EnrollmentDate { get; set; } 
    }
}
