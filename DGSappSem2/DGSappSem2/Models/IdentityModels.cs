﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DGSappSem2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Staffs.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Staffs.StaffAttendance> StaffAttendances { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Assements.Assessment> Assessments { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.FileUpload.FileUploadVm> FileUploadVms { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Events.Event> Events { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Events.BookEvent> BookEvents { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Students.Student> Students { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Events.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Library.Book> Books { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Library.BookCategory> BookCategories { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Library.BookReservation> BookReservations { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.school.Grades> Grades { get; set; }

        public System.Data.Entity.DbSet<DGSappSem2.Models.Classes.Classes> Classes { get; set; }
    }
}