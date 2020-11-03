using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.FileUpload;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Net;

namespace DGSappSem2.Controllers
{
    public class FileUploadVmsController : Controller
    {
      
        public int count = 1;
        System.Guid guid = System.Guid.NewGuid();

        // GET: Files  
        public ActionResult Index(FileUploadVm model)
        {
            var dtFiles = GetFileDetails();

            List<FileUploadVm> list = new List<FileUploadVm>();
            foreach (var item in dtFiles)
            {
                list.Add(new FileUploadVm
                {
                    //FileId = item.FileId,
                    FileId = (count++).ToString(),
                    FileName = item.FileName,
                    FileUrl = item.FileUrl
                });
            }
            model.FileList = list;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            FileUploadVm model = new FileUploadVm
            {
                FileList = new List<FileUploadVm>()
            };
            FileUploadVm file;
            var dtFiles = GetFileDetails();
            foreach (var item in dtFiles)
            {
                file = new FileUploadVm
                {
                    FileId = item.FileId,
                    FileName = item.FileName,
                    FileUrl = item.FileUrl
                };
                model.FileList.Add(file);
            }

            if (files != null)
            {
                //var Extension = Path.GetExtension(files.FileName);
                //var fileName = "my-file-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;
                string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles");
                string path = Path.Combine(defaultPath, files.FileName);
                model.FileUrl = Url.Content(Path.Combine("~/UploadedFiles/", files.FileName));
                model.FileName = files.FileName;

                if (SaveFile(model))
                {
                    files.SaveAs(path);
                    TempData["AlertMessage"] = "Uploaded Successfully !!";
                    return RedirectToAction("Index", "FileUploadVms");
                }
                else
                {
                    ModelState.AddModelError("", "Error In Add File. Please Try Again !!!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please Choose Correct File Type !!");
                return View(model);
            }
            return RedirectToAction("Index", "FileUploadVms");
        }

        private List<FileUploadVm> GetFileDetails()
        {
            //DataTable dtData = new DataTable();
            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //SqlCommand command = new SqlCommand("Select * From tblFileDetails", con);
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dtData);
            //con.Close();
            //return dtData;
            var response = new List<FileUploadVm>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles");

            var test = Directory.GetFiles(path);
            foreach (var entry in test)
            {
                var file = new FileUploadVm
                {

                    FileId = entry,
                    FileName = Path.GetFileName(entry),
                    FileUrl = entry

                };
                guid.ToString();
                response.Add(file);
            }

            return response;
        }

        private bool SaveFile(FileUploadVm model)
        {
            //string strQry = "INSERT INTO tblFileDetails (FileName,FileUrl) VALUES('" +
            //    model.FileName + "','" + model.FileUrl + "')";
            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //SqlCommand command = new SqlCommand(strQry, con);
            //int numResult = command.ExecuteNonQuery();
            //con.Close();
            if (model != null)

            {
                model.FileList.Add(model);
                guid.ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        //public string filePath = @"E:\work\campus work\3rd year 2020\Project work\sem 2\project code\DGSrepo1\DGSappSem2\DGSappSem2\DGSappSem2\Files\DownloadFiles";
        public ActionResult DownloadFile(string filePath)
        {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);


        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }


        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FileUpload assessment = await db.FileUpload.FindAsync(id);
        //    if (assessment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assessment);
        //}

        //// POST: Assessments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    FileUpload assessment = await db.FileUpload.FindAsync(id);
        //    db.Assessments.Remove(assessment);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

    }
}
