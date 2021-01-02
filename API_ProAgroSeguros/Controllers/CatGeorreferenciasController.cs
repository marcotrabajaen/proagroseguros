using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ProAgroSeguros.Models;

namespace API_ProAgroSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatGeorreferenciasController : ControllerBase
    {
        private readonly proagrosegurosContext _context;

        public CatGeorreferenciasController(proagrosegurosContext context)
        {
            _context = context;
        }

        // GET: api/CatGeorreferencias
        [HttpGet]
        [Route("GetCatGeorreferencias")]
        public async Task<ActionResult<IEnumerable<CatGeorreferencia>>> GetCatGeorreferencias()
        {
            return await _context.CatGeorreferencias.ToListAsync();
        }

        // GET: api/CatGeorreferencias/5
        [HttpGet]
        [Route("GetCatGeorreferencia/{id}")]
        public async Task<ActionResult<CatGeorreferencia>> GetCatGeorreferencia(int id)
        {
            var catGeorreferencia = await _context.CatGeorreferencias.FindAsync(id);

            if (catGeorreferencia == null)
            {
                return NotFound();
            }

            return catGeorreferencia;
        }

        // GET: api/CatGeorreferencias/
        [HttpGet]
        [Route("GetCatGeorreferenciaByIdEstado/{id}")]
        public async Task<ActionResult<IEnumerable<CatGeorreferencia>>> GetCatGeorreferenciaByIdEstado(int id)
        {
            var miClase = new { IdEstado = id };
            return await _context.CatGeorreferencias.Where(d => d.IdEstado == miClase.IdEstado).ToListAsync();
        }

        // PUT: api/CatGeorreferencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatGeorreferencia(int id, CatGeorreferencia catGeorreferencia)
        {
            if (id != catGeorreferencia.IdGeorreferencias)
            {
                return BadRequest();
            }

            _context.Entry(catGeorreferencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatGeorreferenciaExists(id))
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

        // POST: api/CatGeorreferencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CatGeorreferencia>> PostCatGeorreferencia(CatGeorreferencia catGeorreferencia)
        {
            _context.CatGeorreferencias.Add(catGeorreferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatGeorreferencia", new { id = catGeorreferencia.IdGeorreferencias }, catGeorreferencia);
        }

        // DELETE: api/CatGeorreferencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatGeorreferencia>> DeleteCatGeorreferencia(int id)
        {
            var catGeorreferencia = await _context.CatGeorreferencias.FindAsync(id);
            if (catGeorreferencia == null)
            {
                return NotFound();
            }

            _context.CatGeorreferencias.Remove(catGeorreferencia);
            await _context.SaveChangesAsync();

            return catGeorreferencia;
        }

        private bool CatGeorreferenciaExists(int id)
        {
            return _context.CatGeorreferencias.Any(e => e.IdGeorreferencias == id);
        }
    }
}
