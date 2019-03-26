using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVC_MySQL.Models;

namespace MVC_MySQL.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MVC_MySQL.Models.SeguroContext _context;

        public DetailsModel(MVC_MySQL.Models.SeguroContext context)
        {
            _context = context;
        }

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
    }
}
