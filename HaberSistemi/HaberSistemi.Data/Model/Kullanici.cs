using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.Model
{
    [Table("Kullanici")]
    public class Kullanici
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(150, ErrorMessage = "Lütfen 50 karakterden fazla değer girmeyiniz...")]
        [Display(Name = "Ad Soyad")]
        [Required]
        public string AdSoyad { get; set; }


        [Display(Name = "E mail")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(16, ErrorMessage = "Lütfen 50 karakterden fazla değer girmeyiniz...")]
        public string Sifre { get; set; }

        [Display(Name ="Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }

        public bool Aktif { get; set; }

        public virtual Rol Rol { get; set; }


    }

}
