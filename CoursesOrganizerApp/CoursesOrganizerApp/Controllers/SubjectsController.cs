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
    public class SubjectsController : Controller
    {
        //private Models.AppContext db = new Models.AppContext();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: subject
        public ActionResult Index()
        {
            var subjects = from subject in db.Subjects
                           orderby subject.SubjectName
                           select subject;
            ViewBag.Subjects = subjects;
            return View();
        }

        public ActionResult Show(int id)
        {
            Subject subject = db.Subjects.Find(id);
            ViewBag.Subject = subject;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Subject sub)
        {
            try
            {
                db.Subjects.Add(sub);
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
            Subject subject = db.Subjects.Find(id);
            ViewBag.Subject = subject;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Subject requestSubject)
        {
            try
            {
                Subject subject = db.Subjects.Find(id);
                if (TryUpdateModel(subject))
                {
                    subject.SubjectName = requestSubject.SubjectName;
                    subject.TeacherName = requestSubject.TeacherName;
                    subject.Description = requestSubject.Description;
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
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}