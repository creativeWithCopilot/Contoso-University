namespace UniversityApi.DTOs
{
    public class CourseDto
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }

    public class CourseCreateDto 
    { 
        public int CourseID { get; set; } // required since CourseID is not auto-generated 
        public string Title { get; set; } 
        public int Credits { get; set; } 
    }

    public class CourseUpdateDto 
    { 
        public int CourseID { get; set; } 
        public string Title { get; set; } 
        public int Credits { get; set; } 
    }
}
