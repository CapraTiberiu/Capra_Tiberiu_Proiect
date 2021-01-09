using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capra_Tiberiu_Proiect.Models
{
    public class TelefonCategory
    {
        public int ID { get; set; }
        public int TelefonID { get; set; }
        public Telefon Telefon { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
