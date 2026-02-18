using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApi.Models
{
    public class Course
    {
        // Use DatabaseGeneratedOption.None to allow manual setting of CourseID
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }

        // Navigation property
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
