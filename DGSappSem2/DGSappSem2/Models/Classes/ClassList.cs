using DGSappSem2.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Classes
{
    public class ClassList
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]

        public int ClassListID { get; set; }
        public int StID { get; set; }
        public Student Student { get; set; }
        //blic virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<_Class> Classes { get; set; }
    }
}