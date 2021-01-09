using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Capra_Tiberiu_Proiect.Data;
using Capra_Tiberiu_Proiect.Models;

namespace Capra_Tiberiu_Proiect.Pages.Producatori
{
    public class IndexModel : PageModel
    {
        private readonly Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext _context;

        public IndexModel(Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext context)
        {
            _context = context;
        }

        public IList<Producator> Producator { get;set; }

        public async Task OnGetAsync()
        {
            Producator = await _context.Producator.ToListAsync();
        }
    }
}
