using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoursesOrganizerApp.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }

        public string Links { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


        public virtual Subject Subject { get; set; }
    }


}