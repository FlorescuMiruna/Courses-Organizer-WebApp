using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesOrganizerApp.Models
{
    public class StudentTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public DateTime Deadline { get; set; }

        public string TeacherEmail { get; set; }
        public string Links { get; set; }
        public int SubjectId { get; set; }

      //  public string UserId { get; set; }
     //   public virtual ApplicationUser User { get; set; }


        public virtual Subject Subject { get; set; }
    }
}