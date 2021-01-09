using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capra_Tiberiu_Proiect.Models
{
    public class Producator
    {
        public int ID { get; set; }

        [Display(Name = "Producator")]
        public string NumeProducator { get; set; }
        public ICollection<Telefon> Telefoane { get; set; }
    }
}
