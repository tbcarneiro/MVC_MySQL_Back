using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_MySQL.Models;

namespace MVC_MySQL.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MVC_MySQL.Models.SeguroContext _context;

        public CreateModel(MVC_MySQL.Models.SeguroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Seguro Seguro { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seguros.Add(Seguro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}