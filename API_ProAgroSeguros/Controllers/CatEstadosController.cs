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
    public class CatEstadosController : ControllerBase
    {
        private readonly proagrosegurosContext _context;

        public CatEstadosController(proagrosegurosContext context)
        {
            _context = context;
        }

        // GET: api/CatEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatEstado>>> GetCatEstados()
        {            
            return await _context.CatEstados.ToListAsync();
        }

        // GET: api/CatEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatEstado>> GetCatEstado(int id)
        {
            var catEstado = await _context.CatEstados.FindAsync(id);

            if (catEstado == null)
            {
                return NotFound();
            }

            return catEstado;
        }
        

        // PUT: api/CatEstados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatEstado(int id, CatEstado catEstado)
        {
            if (id != catEstado.IdEstado)
            {
                return BadRequest();
            }

            _context.Entry(catEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEstadoExists(id))
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

        // POST: api/CatEstados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CatEstado>> PostCatEstado(CatEstado catEstado)
        {
            _context.CatEstados.Add(catEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatEstado", new { id = catEstado.IdEstado }, catEstado);
        }

        // DELETE: api/CatEstados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatEstado>> DeleteCatEstado(int id)
        {
            var catEstado = await _context.CatEstados.FindAsync(id);
            if (catEstado == null)
            {
                return NotFound();
            }

            _context.CatEstados.Remove(catEstado);
            await _context.SaveChangesAsync();

            return catEstado;
        }

        private bool CatEstadoExists(int id)
        {
            return _context.CatEstados.Any(e => e.IdEstado == id);
        }
    }
}
