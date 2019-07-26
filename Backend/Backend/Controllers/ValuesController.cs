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

        // GET api/values/detalles/{id}
        [HttpGet("detalles/{id}")]
        public IActionResult DetalleUsuario(int id)
        {
            //var usuario = _context.Usuario.Find(id);
            var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/values/crearUsuario
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario) //Agregar un nuevo usuario.
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
        [HttpPut("editarUsuario")]
        public async Task<IActionResult> EditarUsuario([FromBody] Usuario usuario) //Editar usuario existente
        {
            var id = usuario.Id;

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
        public IActionResult Eliminar(int id) //Eliminar usuario existente
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

        //Almacenar actividad en realizada
        public IActionResult Actividad (int id, int id_afectada, int id_accion)
        {
            var usLogged = _context.Usuario.FirstOrDefault(u => u.Id == id);

            //agregar registro a BD
            if (usLogged != null)
            {
                Actividad registro = new Actividad {
                    IdUsuarioAdmin = id,
                    IdUsuario = id_afectada,
                    Fecha = DateTime.Now,
                    IdAccion = id_accion
                };

                try
                {
                    _context.Actividad.Add(registro);
                    _context.SaveChanges();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Ok(registro);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
