using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contexts.Data;
using Model.Models;
using Backend.Services;
using Backend.Controllers;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly TestDbContext _context;
        private readonly PassHashService _passHash;
        private readonly JwtService _jwtService;

        public LoginController(TestDbContext context, PassHashService passHash, JwtService jwtService)
        {
            _context = context;
            _passHash = passHash;
            _jwtService = jwtService;
        }

        [HttpGet("login")]
        public IActionResult Validar([FromQuery] string userQ, [FromQuery] string passQ)
        {
            //string userName = userQ;
            //string pass = passQ;

            var user = _context.Usuario.FirstOrDefault(u => u.Usuario1 == userQ);

            if (user == null)
            {
                return BadRequest("Usuario inexistente o incorrecto");
            }
            else if (user.Status == 2)
            {
                return BadRequest("Usuario desactivado");
            }

            //Validacion de contraseña
            if (!_passHash.Validate(passQ, user.HashSalt, user.Password))
            {
                return BadRequest("Contraseña incorrecta");
            }

            //Creando el token
            var jwtToken = _jwtService.CreateToken(userQ);

            if (jwtToken == null)
            {
                return Unauthorized();
            }

            /*Agregar registro de login*/
            UsuarioController userController = new UsuarioController(_context,  _passHash);
            userController.Actividad(user.Id,null,11,"Login");

            return Ok(new {user, jwtToken});
        }
    }
}