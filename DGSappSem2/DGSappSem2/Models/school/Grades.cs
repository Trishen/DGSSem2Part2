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
        public string Grade { get; set; }

        //[Required(ErrorMessage = "enter Grade ")]
        //[Display(Name = "Class")]
        //public string gradeClass { get; set; }

        public ICollection<_Class> Classes { get; set; }

    }
}