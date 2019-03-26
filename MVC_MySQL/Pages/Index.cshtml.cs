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
    public class IndexModel : PageModel
    {
        private readonly MVC_MySQL.Models.SeguroContext _context;

        public IndexModel(MVC_MySQL.Models.SeguroContext context)
        {
            _context = context;
        }

        public IList<Seguro> Seguro { get;set; }

        public async Task OnGetAsync()
        {
            Seguro = await _context.Seguros.ToListAsync();
        }
    }
}
