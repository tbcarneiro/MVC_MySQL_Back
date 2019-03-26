using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_MySQL.Models;

namespace MVC_MySQL.Pages
{
    public class EditModel : PageModel
    {
        private readonly MVC_MySQL.Models.SeguroContext _context;

        public EditModel(MVC_MySQL.Models.SeguroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seguro Seguro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seguro = await _context.Seguros.FirstOrDefaultAsync(m => m.Id == id);

            if (Seguro == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seguro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroExists(Seguro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeguroExists(int id)
        {
            return _context.Seguros.Any(e => e.Id == id);
        }
    }
}
