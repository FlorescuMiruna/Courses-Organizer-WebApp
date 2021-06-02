using CoursesOrganizerApp.Models;
using CoursesOrganizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesOrganizerApp.Controllers
{
    [Authorize]
    public class StudentTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var stasks = db.StudentTasks.Include("Subject");
            ViewBag.StudentTasks = stasks;

            return View();
        }

        public ActionResult Show(int id)
        {
            StudentTask stask = db.StudentTasks.Find(id);
            ViewBag.StudentTask = stask;
            ViewBag.Subject = stask.Subject;

            return View();

        }

        public ActionResult New()
        {
            var subjects = from sub in db.Subjects
                           select sub;
            ViewBag.Subjects = subjects;
            return View();
        }

        [HttpPost]
        public ActionResult New(StudentTask stask)
        {
            try
            {
                db.StudentTasks.Add(stask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

   /*     public ActionResult Edit(int id)
        {

            Course course = db.Courses.Find(id);
            ViewBag.Course = course;
            ViewBag.Subject = course.Subject;
            var subjects = from sub in db.Subjects
                           select sub;
            ViewBag.Subjects = subjects;
            return View();
        }


        [HttpPut]
        public ActionResult Edit(int id, Course requestCourse)
        {
            try
            {
                Course course = db.Courses.Find(id);
                if (TryUpdateModel(course))
                {
                    course.Title = requestCourse.Title;
                    course.Date = requestCourse.Date;
                    course.Content = requestCourse.Content;
                    course.SubjectId = requestCourse.SubjectId;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }*/

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            StudentTask stask = db.StudentTasks.Find(id);
            db.StudentTasks.Remove(stask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}