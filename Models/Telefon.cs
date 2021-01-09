using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capra_Tiberiu_Proiect.Models
{
    public class Telefon
    {
        public int ID { get; set; }

        public string Model { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }
        public string Memorie { get; set; }

        [Range(100, 5000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Categorii")]
        public ICollection<TelefonCategory> TelefonCategories { get; set; }
    }
}
