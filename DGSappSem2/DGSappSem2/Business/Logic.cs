using DGSappSem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Business
{
    public class Logic
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        public static void UpdateBookStatus(int bookId, string status)
        {
            var bk = db.Books.Find(bookId);
            bk.Status = status;
            db.Entry(bk).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public static bool CheckDate(DateTime dateTime)
        {
            return dateTime >= DateTime.Now.Date;
        }
    }
}