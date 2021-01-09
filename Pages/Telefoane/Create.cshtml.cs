using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capra_Tiberiu_Proiect.Data;
using Capra_Tiberiu_Proiect.Models;

namespace Capra_Tiberiu_Proiect.Pages.Telefoane
{
    public class CreateModel : TelefonCategoriesPageModel
    {
        private readonly Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext _context;

        public CreateModel(Capra_Tiberiu_Proiect.Data.Capra_Tiberiu_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            var telefon = new Telefon();
            telefon.TelefonCategories = new List<TelefonCategory>();
            PopulateAssignedCategoryData(_context, telefon);
            return Page();
        }

        [BindProperty]
        public Telefon Telefon { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newTelefon = new Telefon();
            if (selectedCategories != null)
            {
                newTelefon.TelefonCategories = new List<TelefonCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new TelefonCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newTelefon.TelefonCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Telefon>(
            newTelefon,
            "Telefon",
            i => i.Model, i => i.ProducatorID,
            i => i.Memorie, i => i.Pret))
            {
                _context.Telefon.Add(newTelefon);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newTelefon);
            return Page();
        }
    }
}
