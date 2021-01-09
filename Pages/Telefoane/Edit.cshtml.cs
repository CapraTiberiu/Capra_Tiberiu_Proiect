using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capra_Tiberiu_Proiect.Data;
using Capra_Tiberiu_Proiect.Models;

namespace Capra_Tiberiu_Proiect.Pages.Telefoane
{
    public class EditModel : TelefonCategoriesPageModel
    {
        private readonly Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext _context;

        public EditModel(Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telefon Telefon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telefon = await _context.Telefon
                        .Include(b => b.Producator)
                        .Include(b => b.TelefonCategories).ThenInclude(b => b.Category)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            if (Telefon == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Telefon);

            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var telefonToUpdate = await _context.Telefon
            .Include(i => i.Producator)
            .Include(i => i.TelefonCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (telefonToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Telefon>(
            telefonToUpdate,
            "Telefon",
            i => i.Model, i => i.ProducatorID,
            i => i.Memorie, i => i.Pret))
            {
                UpdateTelefonCategories(_context, selectedCategories, telefonToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateTelefonCategories(_context, selectedCategories, telefonToUpdate);
            PopulateAssignedCategoryData(_context, telefonToUpdate);
            return Page();
        }
    }


    

}

