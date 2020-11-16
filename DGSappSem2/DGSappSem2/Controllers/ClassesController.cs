using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.Classes;
using DGSappSem2.Models.school;

namespace DGSappSem2.Controllers
{
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            Dictionary<int, string> teacherCollection = GetTeacherNameComboCollection();
            var classes = new Classes
            {
                GradeNameCollection = db.Grades.Select(x => x.GradeName).ToList(),
                TeacherNameCollection = teacherCollection.Values.ToList()
            };

            return View(classes);
        }

        private Dictionary<int, string> GetTeacherNameComboCollection()
        {
            var teacherCollection = new Dictionary<int, string>();

            var collection = db.Staffs.ToList();

            foreach (var entry in collection)
            {
                if (entry.Position != Position.Principle.ToString())
                {
                    var displayName = $"{entry.Title}. {entry.Name} {entry.Surname}";

                    teacherCollection.Add(entry.StaffId, displayName);
                }
            }

            return teacherCollection;
        }

        private Dictionary<int, string> GetGradeNameComboCollection()
        {
            var teacherCollection = new Dictionary<int, string>();

            var collection = db.Grades.ToList();

            foreach (var entry in collection)
            {
                teacherCollection.Add(entry.GradeId, entry.GradeName);
            }


            return teacherCollection;
        }



        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName,GradeName,MaxNoOfStudentsInClass,AssignedTeacher")] Classes classes)
        {
            Dictionary<int, string> teacherCollection = GetTeacherNameComboCollection();
            Dictionary<int, string> gradeCollection = GetGradeNameComboCollection();

            classes.GradeId = FindFirstKeyByValue(gradeCollection, classes.GradeName);
            classes.MaxNoOfClasses = db.Grades.Find(classes.GradeId).MaxNoOfClasses;
            classes.StaffId = FindFirstKeyByValue(teacherCollection, classes.AssignedTeacher);

            if (ModelState.IsValid)
            {
                db.Classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classes);
        }

        public int FindFirstKeyByValue(Dictionary<int, string> dict, string value)
        {
            foreach (KeyValuePair<int, string> pair in dict)
            {
                if (EqualityComparer<string>.Default.Equals(pair.Value, value))
                {
                    return pair.Key;
                }
            }
            return default;
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            Dictionary<int, string> teacherCollection = GetTeacherNameComboCollection();
            Dictionary<int, string> gradeCollection = GetGradeNameComboCollection();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);

            classes.GradeNameCollection = db.Grades.Select(x => x.GradeName).ToList();
            classes.TeacherNameCollection = teacherCollection.Values.ToList();

            classes.GradeId = FindFirstKeyByValue(gradeCollection, classes.GradeName);
            classes.MaxNoOfClasses = db.Grades.Find(classes.GradeId).MaxNoOfClasses;
            classes.StaffId = FindFirstKeyByValue(teacherCollection, classes.AssignedTeacher);

            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName,Grade,GradeId,GradeName,MaxNoOfClasses,Staff,StaffId,AssignedTeacher,MaxNoOfStudentsInClass")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classes);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classes classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
