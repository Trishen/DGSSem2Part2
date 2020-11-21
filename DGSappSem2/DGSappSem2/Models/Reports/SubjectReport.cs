using DGSappSem2.Models.Assements;
using DGSappSem2.Models.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Reports
{
    public class SubjectReport
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int SubjectReportID { get; set; }

        public int SubjectID { get; set; }
        public Subject.Subject Subjects { get; set; }

        public int AssesssmentId { get; set; }
        public Assessment Assessments { get; set; }

    }
}