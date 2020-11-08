using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Business;
using DGSappSem2.Models;
using DGSappSem2.Models.Library;
using Microsoft.AspNet.Identity;

namespace DGSappSem2.Controllers
{
    public class BookReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookReservations
        public ActionResult Index()
        {
            return View(db.BookReservations.ToList());
        }

        // GET: BookReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReservation bookReservation = db.BookReservations.Find(id);
            if (bookReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookReservation);
        }

        // GET: BookReservations/Create
        public ActionResult Create(int? id)
        {
            Session["BookId"] = id;
            return View();
        }

        // POST: BookReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,BookId,ReservationDate,StudentEmail,CollectionDate,ReturnDate,Status")] BookReservation bookReservation)
        {
            var userName = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                if (Logic.CheckDate(bookReservation.CollectionDate))
                {
                    bookReservation.BookId = int.Parse(Session["BookId"].ToString());
                    bookReservation.StudentEmail = userName;
                    bookReservation.ReservationDate = DateTime.Now.Date;
                    bookReservation.ReturnDate = bookReservation.CollectionDate.AddDays(3);
                    bookReservation.Status = "Reserved";
                    db.BookReservations.Add(bookReservation);
                    db.SaveChanges();
                    //Logic.UpdateBookStatus(bookReservation.BookId, "Reserved");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "You can not select a date that has already passed");
                    return View(bookReservation);
                }

            }

            return View(bookReservation);
        }

        // GET: BookReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReservation bookReservation = db.BookReservations.Find(id);
            if (bookReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookReservation);
        }

        // POST: BookReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,BookId,ReservationDate,StudentEmail,CollectionDate,ReturnDate,Status")] BookReservation bookReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookReservation);
        }

        // GET: BookReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReservation bookReservation = db.BookReservations.Find(id);
            if (bookReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookReservation);
        }

        // POST: BookReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookReservation bookReservation = db.BookReservations.Find(id);
            db.BookReservations.Remove(bookReservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnBook(int id)
        {
            Logic.UpdateBookStatus(id, "Available");
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
