using DGSappSem2.Models.Classes;
using DGSappSem2.Models.school;
using DGSappSem2.Models.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Staffs
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Select title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Last name")]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Choose staff gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter date of birth")]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Enter staff's home address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter postal code")]
        public string PostalCode { get; set; }

        public ICollection<StaffTimetable> staffTimetables { get; set; }
        [Required(ErrorMessage = "Select staff position")]
        public string Position { get; set; }
    }
}