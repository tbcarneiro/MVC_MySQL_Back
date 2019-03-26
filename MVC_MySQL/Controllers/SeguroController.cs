using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_MySQL.Models;

namespace MVC_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private readonly SeguroContext _context;

        public SeguroController(SeguroContext context)
        {
            _context = context;
            //GerarDados.Initialize(_context);
        }

        // GET: api/Seguro
        [HttpGet]
        public IEnumerable<Seguro> GetSeguros()
        {
            return _context.Seguros;
        }

        // GET: api/Seguro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeguro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seguro = await _context.Seguros.FindAsync(id);

            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }

        // PUT: api/Seguro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguro([FromRoute] int id, [FromBody] Seguro seguro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seguro.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Seguro
        [HttpPost]
        public async Task<IActionResult> PostSeguro([FromBody] Seguro seguro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguro", new { id = seguro.Id }, seguro);
        }

        // DELETE: api/Seguro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seguro = await _context.Seguros.FindAsync(id);
            if (seguro == null)
            {
                return NotFound();
            }

            _context.Seguros.Remove(seguro);
            await _context.SaveChangesAsync();

            return Ok(seguro);
        }

        private bool SeguroExists(int id)
        {
            return _context.Seguros.Any(e => e.Id == id);
        }
    }
}