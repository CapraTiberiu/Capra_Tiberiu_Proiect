using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capra_Tiberiu_Proiect.Models
{
    public class TelefonData
    {
        public IEnumerable<Telefon> Telefoane { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TelefonCategory> TelefonCategories { get; set; }
    }
}
