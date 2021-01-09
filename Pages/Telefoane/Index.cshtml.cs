using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Capra_Tiberiu_Proiect.Data;
using Capra_Tiberiu_Proiect.Models;

namespace Capra_Tiberiu_Proiect.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext _context;

        public IndexModel(Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext context)
        {
            _context = context;
        }

        public IList<Telefon> Telefon { get;set; }
        public TelefonData TelefonD { get; set; }
        public int TelefonID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            TelefonD = new TelefonData();

            TelefonD.Telefoane = await _context.Telefon
            .Include(b => b.Producator)
            .Include(b => b.TelefonCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Model)
            .ToListAsync();
            if (id != null)
            {
                TelefonID = id.Value;
                Telefon telefon = TelefonD.Telefoane
                .Where(i => i.ID == id.Value).Single();
                TelefonD.Categories = telefon.TelefonCategories.Select(s => s.Category);
            }
        }

    }
}
