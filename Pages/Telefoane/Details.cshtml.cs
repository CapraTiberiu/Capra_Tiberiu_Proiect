﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext _context;

        public DetailsModel(Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext context)
        {
            _context = context;
        }

        public Telefon Telefon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telefon = await _context.Telefon.FirstOrDefaultAsync(m => m.ID == id);

            if (Telefon == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
