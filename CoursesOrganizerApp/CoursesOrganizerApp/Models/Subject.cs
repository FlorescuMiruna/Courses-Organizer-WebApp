using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesOrganizerApp.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StudentTask> StudentTasks { get; set; }
    }
}