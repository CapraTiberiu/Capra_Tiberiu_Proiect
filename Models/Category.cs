using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Capra_Tiberiu_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Categorii")]
        public string CategoryName { get; set; }
        public ICollection<TelefonCategory> TelefonCategories { get; set; }
    }
}
