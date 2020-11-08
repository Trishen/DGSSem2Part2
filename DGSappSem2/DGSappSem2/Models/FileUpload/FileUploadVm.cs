using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.FileUpload
{
    public class FileUploadVm
    {
        [Key]
        public int Id { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please select file.")]
        //public HttpPostedFileBase FileUpload { get; set; }
    }
}