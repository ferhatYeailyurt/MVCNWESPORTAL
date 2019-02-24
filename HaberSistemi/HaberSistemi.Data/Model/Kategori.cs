using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2,ErrorMessage ="{0} karakterden az olamaz."),MaxLength(150,ErrorMessage ="150 karakterden fazla giremezsiniz")]
        public string KategoriAdi { get; set; }

        public int ParentId { get; set; }

        public bool AktifMi { get; set; }

        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden fazla giremezsiniz")]
        public string URL { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual ICollection<Haber> Haber { get; set; }
    }
}
