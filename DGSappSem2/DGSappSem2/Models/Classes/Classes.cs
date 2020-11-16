using DGSappSem2.Models.school;
using DGSappSem2.Models.Staffs;
using DGSappSem2.Models.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGSappSem2.Models.Classes
{
    public class Classes
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Grade Id")]
        [ForeignKey("GradeId")]
        public virtual Grades Grade { get; set; }

        public int? GradeId { get; set; }

        [Display(Name = "Grade Name")]
        public string GradeName { get; set; }

        [Display(Name = "Max No. Of Classes")]
        public int MaxNoOfClasses { get; set; }

        [Display(Name = "Assigned Teacher Id")]
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        public int? StaffId { get; set; }

        [Display(Name = "Assigned Teacher")]
        public string AssignedTeacher { get; set; }

        [Display(Name = "Max No. Of Students In A Class")]
        [Required]
        [Range(1, 40)]
        public int MaxNoOfStudentsInClass { get; set; }


        public IEnumerable<string> GradeNameCollection { get; set; }
        public IEnumerable<string> TeacherNameCollection { get; set; }
    }

}