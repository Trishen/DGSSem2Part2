using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.FileUpload;

namespace DGSappSem2.Controllers
{
    public class FileUploadVmsController : Controller
    {
        public ActionResult Index()
        {
            var blobbusiness = new BlobBusiness();
            return View(blobbusiness.GetListOfBlobs("images"));
        }

        [ActionName("Upload")]
        public ActionResult Upload()
        {
            ViewBag.Message = "Upload page.";

            return View();
        }
        [HttpPost]
        [ActionName("Upload")]
        public async Task<ActionResult> UploadAsync(FileUploadVm photo)
        {
            if (ModelState.IsValid)
            {
                //if (photo.FileUpload != null && photo.FileUpload.ContentLength > 0)
                //{
                //    var blobbusiness = new BlobBusiness();
                //    await blobbusiness.UploadPhotoAsync("images", photo.FileUpload);
                //}
            }

            return RedirectToAction("Index");

        }

        //    private ApplicationDbContext db = new ApplicationDbContext();

        //    // GET: FileUploadVms
        //    public ActionResult Index()
        //    {
        //        return View(db.FileUploadVms.ToList());
        //    }

        //    // GET: FileUploadVms/Details/5
        //    public ActionResult Details(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        FileUploadVm fileUploadVm = db.FileUploadVms.Find(id);
        //        if (fileUploadVm == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(fileUploadVm);
        //    }

        //    // GET: FileUploadVms/Create
        //    public ActionResult Create()
        //    {
        //        return View(new FileUploadVm());
        //    }

        //    // POST: FileUploadVms/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "FileId,FileName,FileUrl")] FileUploadVm fileUploadVm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.FileUploadVms.Add(fileUploadVm);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(fileUploadVm);
        //    }

        //    // GET: FileUploadVms/Edit/5
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        FileUploadVm fileUploadVm = db.FileUploadVms.Find(id);
        //        if (fileUploadVm == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(fileUploadVm);
        //    }

        //    // POST: FileUploadVms/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "FileId,FileName,FileUrl")] FileUploadVm fileUploadVm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(fileUploadVm).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(fileUploadVm);
        //    }

        //    // GET: FileUploadVms/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        FileUploadVm fileUploadVm = db.FileUploadVms.Find(id);
        //        if (fileUploadVm == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(fileUploadVm);
        //    }

        //    // POST: FileUploadVms/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        FileUploadVm fileUploadVm = db.FileUploadVms.Find(id);
        //        db.FileUploadVms.Remove(fileUploadVm);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
