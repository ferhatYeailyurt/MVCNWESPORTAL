using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.Model
{
    [Table("Haber")]
    public class Haber
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Haber Başlığı")]
        [MaxLength(255,ErrorMessage ="Çok Fazla Değer Girdiniz")]
        [Required]
        public string Baslik { get; set; }


        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public int Okunma { get; set; }

        [Display(Name = "Aktif")]
        public bool AktifMi { get; set; }


        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [MaxLength(255, ErrorMessage = "Çok Fazla  Girdiniz")]
        public string Resim { get; set; }

        public virtual ICollection<Resim> Resims { get; set; }


        public virtual Kategori Kategori { get; set; }

    }
}
