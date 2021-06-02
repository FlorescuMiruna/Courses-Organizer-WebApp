using CoursesOrganizerApp.Models;
using CoursesOrganizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesOrganizerApp.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include("Subject");
            ViewBag.Courses = courses;

            return View();
        }

        public ActionResult Show(int id)
        {
            Course course = db.Courses.Find(id);
            ViewBag.Course = course;
            ViewBag.Subject = course.Subject;

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
        public ActionResult New(Course course)
        {
            try
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
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
                    course.Links = requestCourse.Links;
                    course.SubjectId = requestCourse.SubjectId;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}