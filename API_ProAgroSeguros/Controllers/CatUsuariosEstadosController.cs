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
    public class CatUsuariosEstadosController : ControllerBase
    {
        private readonly proagrosegurosContext _context;

        public CatUsuariosEstadosController(proagrosegurosContext context)
        {
            _context = context;
        }

        // GET: api/CatUsuariosEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatUsuarioEstado>>> GetCatUsuarioEstados()
        {
            return await _context.CatUsuarioEstados.ToListAsync();
        }

        // GET: api/CatUsuariosEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatUsuarioEstado>> GetCatUsuarioEstado(int id)
        {
            var catUsuarioEstado = await _context.CatUsuarioEstados.FindAsync(id);

            if (catUsuarioEstado == null)
            {
                return NotFound();
            }

            return catUsuarioEstado;
        }

        // PUT: api/CatUsuariosEstados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatUsuarioEstado(int id, CatUsuarioEstado catUsuarioEstado)
        {
            if (id != catUsuarioEstado.IdUsuarioEstado)
            {
                return BadRequest();
            }

            _context.Entry(catUsuarioEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatUsuarioEstadoExists(id))
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

        // POST: api/CatUsuariosEstados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CatUsuarioEstado>> PostCatUsuarioEstado(CatUsuarioEstado catUsuarioEstado)
        {
            _context.CatUsuarioEstados.Add(catUsuarioEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatUsuarioEstado", new { id = catUsuarioEstado.IdUsuarioEstado }, catUsuarioEstado);
        }

        // DELETE: api/CatUsuariosEstados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatUsuarioEstado>> DeleteCatUsuarioEstado(int id)
        {
            var catUsuarioEstado = await _context.CatUsuarioEstados.FindAsync(id);
            if (catUsuarioEstado == null)
            {
                return NotFound();
            }

            _context.CatUsuarioEstados.Remove(catUsuarioEstado);
            await _context.SaveChangesAsync();

            return catUsuarioEstado;
        }

        private bool CatUsuarioEstadoExists(int id)
        {
            return _context.CatUsuarioEstados.Any(e => e.IdUsuarioEstado == id);
        }
    }
}
