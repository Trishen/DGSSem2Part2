using DGSappSem2.Models.Classes;
using DGSappSem2.Models.Reports;
using DGSappSem2.Models.school;
using DGSappSem2.Models.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Subject
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "Enter a Subject Name")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Display(Name = "Grade Id")]
        [ForeignKey("GradeId")]
        public virtual Grades Grade { get; set; }

        public int? GradeId { get; set; }

        [Display(Name = "Grade Name")]
        public List<string> SupportedGradesCollection { get; set; }


        public IEnumerable<string> GradeNameCollection { get; set; }

        //public virtual ICollection<Course_Material> Course_Materials { get; set; }
        //public virtual ICollection<SubjectReport> SubjectReports { get; set; }
        //public virtual ICollection<Classes.Classes> Classes { get; set; }
    }
}