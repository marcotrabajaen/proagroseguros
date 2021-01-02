using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API_ProAgroSeguros.Models;
using API_ProAgroSeguros.ViewModels;

namespace API_ProAgroSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatUsuariosController : ControllerBase
    {
        private readonly proagrosegurosContext _context;

        public CatUsuariosController(proagrosegurosContext context)
        {
            _context = context;
        }       

        // GET: api/CatUsuarios
        [HttpGet]
        [Route("GetCatUsuarios")]
        public async Task<ActionResult<IEnumerable<CatUsuario>>> GetCatUsuarios()
        {
            //return await _context.CatUsuarios.ToListAsync();
            var Usuarios = await _context.CatUsuarios.ToListAsync();
            return Ok(Usuarios);
        }

        // GET: api/CatUsuarios/5
        [HttpGet("{id}")]
        [Route("GetCatUsuario/{id}")]
        public async Task<ActionResult<CatUsuario>> GetCatUsuario(int id)
        {
            var catUsuario = await _context.CatUsuarios.FindAsync(id);
            if (catUsuario == null)
            {
                return NotFound();
            }

            return Ok(catUsuario);
        }

        // PUT: api/CatUsuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("PutCatUsuario")]
        public async Task<IActionResult> PutCatUsuario(int id, CatUsuario catUsuario)
        {
            if (id != catUsuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(catUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatUsuarioExists(id))
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

        // POST: api/CatUsuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("PostCatUsuario")]
        public async Task<ActionResult<CatUsuario>> PostCatUsuario(CatUsuario catUsuario)
        {
            _context.CatUsuarios.Add(catUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatUsuario", new { id = catUsuario.IdUsuario }, catUsuario);
        }

        // DELETE: api/CatUsuarios/5
        [HttpDelete("{id}")]
        [Route("DeleteCatUsuario/{id}")]
        public async Task<ActionResult<CatUsuario>> DeleteCatUsuario(int id)
        {
            var catUsuario = await _context.CatUsuarios.FindAsync(id);
            if (catUsuario == null)
            {
                return NotFound();
            }

            _context.CatUsuarios.Remove(catUsuario);
            await _context.SaveChangesAsync();

            //return catUsuario;
            return Ok();
        }

        private bool CatUsuarioExists(int id)
        {
            return _context.CatUsuarios.Any(e => e.IdUsuario == id);
        }

        [HttpPost("Login")]
        public ActionResult Login(Login MiLogin)
        {
            var UnUsuario = (from st in _context.CatUsuarios
                             where st.Rfc == MiLogin.RFC && st.Contrasenia == MiLogin.Contrasenia
                             select new
                             {
                                 IdUsuario = st.IdUsuario,
                                 Nombre = st.Nombre,
                                 Rfc = st.Rfc,
                                 FechaCreacion = st.FechaCreacion
                             }).First();

            if (UnUsuario == null)
                return NotFound("Usuario no existe!!");
            else
            {   
                var MiUsuarioEstado = _context.CatUsuarioEstados.Where(e => e.IdUsuario == UnUsuario.IdUsuario).First();
                if (MiUsuarioEstado == null)
                    return NotFound("Usuario no tiene Estado!!");
                else
                {
                    Usuario MiUsuario = new Usuario();
                    MiUsuario.IdUsuario = (int)MiUsuarioEstado.IdUsuario;
                    MiUsuario.IdEstado = (int)MiUsuarioEstado.IdEstado;
                    MiUsuario.Nombre = UnUsuario.Nombre;
                    MiUsuario.FechaCreacion = UnUsuario.FechaCreacion;
                    MiUsuario.Rfc = UnUsuario.Rfc;

                    return Ok(MiUsuario);
                }
            }

        }

    }
}
