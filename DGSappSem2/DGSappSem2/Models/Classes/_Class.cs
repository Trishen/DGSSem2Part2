using DGSappSem2.Models.school;
using DGSappSem2.Models.Staffs;
using DGSappSem2.Models.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Classes
{
    public class _Class
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }
        public string Grade { get; set; }
        public int SubjectID { get; set; }

        public int ClassListID { get; set; }

        public int StaffID { get; set; }

        public ClassList ClassLists { get; set; }

        public Staff Staffs { get; set; }
        public _Subject Subjects { get; set; }
       
        public ICollection<Grades>grades{ get; set; }

    }
}