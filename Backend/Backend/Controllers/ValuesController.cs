using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.ViewModels;

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
        public IActionResult Usuarios()
        {
            //IEnumerable<Usuario> usuarios = (from us in _context.Usuario
            //                          select us);

            //List<Usuario> usuarios = _context.Usuario.Include(u => u.Role).ToList();
            var usuarios = _context.Usuario
                            .Include(r => r.Role)
                            .Select(p => new  {
                               p.Id,
                               p.Nombre,
                               p.Apellido,
                               p.Direccion,
                               p.Telefono,
                               p.Usuario1,
                               p.RoleId,
                               p.Role
                            }).ToList();
            return Ok(usuarios);
        }

        // GET api/values/detalles/4
        [HttpGet("detalles/{id}")]
        public IActionResult DetalleUsuario(int id)
        {
            //var usuario = _context.Usuario.Find(id);
            //var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);
            var usuario = _context.Usuario
                            .Where(u => u.Id == id)
                            .Select(p => new {
                                p.Id,
                                p.Nombre,
                                p.Apellido,
                                p.Direccion,
                                p.Telefono,
                                p.Usuario1,
                                p.RoleId
                            })
                            .FirstOrDefault();

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

        // PUT api/values/editarUsuario
        [HttpPut("editarUsuario")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioViewModel usuario) //Editar usuario existente
        {
            //var id = usuario.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userNew = _context.Usuario.FirstOrDefault(u => u.Id == usuario.Id);

            if (userNew == null)
            {
                return BadRequest();
            }
            else
            {
                userNew.Nombre = usuario.Nombre;
                userNew.Apellido = usuario.Apellido;
                userNew.Direccion = usuario.Direccion;
                userNew.Telefono = usuario.Telefono;
                userNew.Usuario1 = usuario.Usuario1;
                userNew.RoleId = usuario.RoleId;
                
                //_context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return Ok(usuario);
        }

        // DELETE api/values/eliminarUsuario/3
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
        //POST api/values/log
        [HttpPost("log")]
        public IActionResult Actividad ([FromQuery] int idLog, [FromQuery]int idAfectada, [FromQuery] int idAccion)
        {
            var usLogged = _context.Usuario.FirstOrDefault(u => u.Id == idLog);

            //agregar registro a BD
            if (usLogged != null)
            {
                Actividad registro = new Actividad {
                    IdUsuarioAdmin = idLog,
                    IdUsuario = idAfectada,
                    Fecha = DateTime.Now,
                    IdAccion = idAccion
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

        //PUT api/values/cambiarPassword/3
        [HttpPut("cambiarPassword/{id}")]
        public IActionResult CambiarPassword (int id, [FromQuery] string oldPass, [FromQuery] string newPass)//cambio de contrasena
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id && u.Password == oldPass);

            if (usuario == null)
            {
                return BadRequest();
            }

            usuario.Password = newPass;
            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}
