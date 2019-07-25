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

        // GET api/values/5
        [HttpGet("getDetalle/{id}")]
        public IActionResult DetalleUsuario(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                NotFound();
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("eliminarUsuario/{id}")]
        public IActionResult Eliminar(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                NotFound();
            }

            _context.Remove(usuario);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
