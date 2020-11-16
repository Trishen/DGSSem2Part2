using DGSappSem2.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.school
{
    public class Grades
    {

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }

        [Required(ErrorMessage = "enter Grade ")]
        [Display(Name = "Grade")]
        public string GradeName { get; set; }

        [Display(Name = "Max No. Of Students In Grade")]
        [Required]
        [Range(1, 500)]
        public int MaxNoOfStudentsInGrade { get; set; }

        [Display(Name = "Max No. Of Classes")]
        [Required]
        [Range(1, 5)]
        public int MaxNoOfClasses { get; set; }

        [Display(Name = "No. Of Students")]
        public int NoOfStudents { get; set; }
    }
}