using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.Model
{
    [Table("Resim")]
    public class Resim
    {
        public int Id { get; set; }
        public string ResimUrl { get; set; }

        public Haber Haber { get; set; }

    }
}
