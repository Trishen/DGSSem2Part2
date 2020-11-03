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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public List<FileUploadVm> FileList { get; set; }
    }
}