using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TestDbContext _context;

        public ValuesController(TestDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Usuario> Usuarios()
        {
            IEnumerable<Usuario> usuarios = (from us in _context.Usuario
                                      select us);

            return usuarios;
        }

        // GET api/values/Detalles/{id}
        [HttpGet("Detalles/{id}")]
        public IActionResult DetalleUsuario(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            //var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);
            return Ok(usuario);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT api/values/editarUsuario/{id}
        [HttpPut("editarUsuario/{id}")]
        public async Task<IActionResult> EditarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return Ok(usuario);
        }

        // DELETE api/values/eliminarUsuario/{id}
        [HttpDelete("eliminarUsuario/{id}")]
        public IActionResult Eliminar(int id)
        {
            var usuario = _context.Usuario.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
               return NotFound();
            }

            _context.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);

        }
    }
}
