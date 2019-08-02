using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.ViewModels;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/values")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TestDbContext _context;
        private readonly PassHashService _passHash;
        public UsuarioController(TestDbContext context, PassHashService passHash)
        {
            _context = context;
            _passHash = passHash;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Usuarios()
        {
            //List<Usuario> usuarios = _context.Usuario.Include(u => u.Role).ToList();

            var usuarios = _context.Usuario
                            .Include(r => r.Role)
                            .Select(p => new {
                                p.Id,
                                p.Nombre,
                                p.Apellido,
                                p.Direccion,
                                p.Telefono,
                                p.Usuario1,
                                p.RoleId,
                                p.Role,
                                p.Status
                            }).ToList();

            return Ok(usuarios);
        }

        // GET api/values/detalles/4
        [HttpGet("detalles/{id}")]
        public IActionResult DetalleUsuario(int id)
        {
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
                                p.RoleId,
                                p.Status
                            })
                            .FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario, [FromQuery] int idAdmin) //Agregar un nuevo usuario.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userExist = _context.Usuario.Select(u => u.Usuario1).Contains(usuario.Usuario1);

            if (userExist)
            {
                return BadRequest("Usuario Existente");
            }

            var randomSalt = _passHash.CreateSalt();
            var hash = _passHash.CreateHash(usuario.Password, randomSalt);


            var userNew = new Usuario() {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Usuario1 = usuario.Usuario1,
                RoleId = usuario.RoleId,
                Password = hash,
                HashSalt = randomSalt,
                Status = 1
            };

            _context.Usuario.Add(userNew);
            _context.SaveChanges();

            Actividad(idAdmin, userNew.Id, 1, "Usuarios"); //Agregando registro al log

            return Ok(userNew);

        }

        // PUT api/values/editarUsuario
        [HttpPut("editarUsuario")]
        public IActionResult EditarUsuario([FromBody] UsuarioViewModel usuario, [FromQuery] int idAdmin) //Editar usuario existente
        {
            //var id = usuario.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userEdited = _context.Usuario.FirstOrDefault(u => u.Id == usuario.Id);
            var userAct = userEdited;

            if (userEdited == null)
            {
                return BadRequest();
            }

                userEdited.Nombre = usuario.Nombre;
                userEdited.Apellido = usuario.Apellido;
                userEdited.Direccion = usuario.Direccion;
                userEdited.Telefono = usuario.Telefono;
                userEdited.Usuario1 = usuario.Usuario1;
                userEdited.RoleId = usuario.RoleId;
                userEdited.Status = usuario.Status;

                //_context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();

                Actividad(idAdmin, usuario.Id, 2, "Usuarios");// Agregando registro al log

            if (userAct.Status == 1 && usuario.Status == 2)
            {
                Actividad(idAdmin, usuario.Id, 14, "Usuarios");// Agregando registro al log
            }

            if (userAct.Status == 2 && usuario.Status == 1)
            {
                Actividad(idAdmin, usuario.Id, 15, "Usuarios");// Agregando registro al log
            }

            return Ok(usuario);
        }

        // DELETE api/values/eliminarUsuario/3
        [HttpDelete("eliminarUsuario/{id}")]
        public IActionResult Eliminar(int id, [FromQuery] int idAdmin) //Eliminar (desactivar) usuario existente
        {
            var usuario = _context.Usuario.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
               return NotFound();
            }

            usuario.Status = 2; //cambiando a status inactivo

            _context.SaveChanges();

            Actividad(idAdmin, id, 7, "Usuarios"); // agregando registro al log

            return Ok(usuario);

        }

        //Almacenar actividad en realizada
        [HttpPost("log")]
        public IActionResult Actividad([FromQuery] int idAdmin, [FromQuery]int? idAfectada, [FromQuery] int idAccion, [FromQuery] string modulo)
        {
            var usLogged = _context.Usuario.FirstOrDefault(u => u.Id == idAdmin);

            //agregar registro a BD
            if (usLogged != null)
            {

                Actividad registro = new Actividad
                {
                    IdUsuarioAdmin = idAdmin,
                    IdUsuario = idAfectada,
                    Fecha = DateTime.Now,
                    IdAccion = idAccion,
                    Modulo = modulo
                };

                try
                {
                    _context.Actividad.Add(registro);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Ok(registro);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("verificarPass/{id}")]
        public IActionResult VerificarPassword (int id, [FromQuery] string oldPass)
        {
            var user = _context.Usuario.FirstOrDefault(u => u.Id == id);

            var oldSalt = user.HashSalt;

            if (!_passHash.Validate(oldPass, user.HashSalt, user.Password))
            {
                return BadRequest();
            }

            return Ok("Contraseña coincide");
        }

        //PUT api/values/cambiarPassword/3
        [HttpPut("cambiarPass/{id}")]
        public IActionResult CambiarPassword (int id, [FromQuery] string newPass, [FromQuery] int idAdmin)//cambio de contrasena
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return BadRequest();
            }

            var newSalt = _passHash.CreateSalt();
            var newHash = _passHash.CreateHash(newPass, newSalt);

            usuario.Password = newHash;
            usuario.HashSalt = newSalt;

            _context.SaveChanges();

            Actividad(idAdmin, id, 13, "Usuarios");//Agregando registro al log.

            return Ok(usuario);
        }
    }
}
