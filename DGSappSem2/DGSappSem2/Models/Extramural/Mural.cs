using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DGSappSem2.Models.Extramural
{
    public class Mural
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MuralId { get; set; }
        [DisplayName("Mural Name")]
        public string Title { get; set; }
    }
}