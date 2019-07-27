using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contexts.Data;
using Model.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly TestDbContext _context;
        private readonly PassHashService _passHash;

        public LoginController(TestDbContext context, PassHashService passHash)
        {
            _context = context;
            _passHash = passHash;
        }

        [HttpGet("login")]
        public IActionResult Validar([FromQuery] string userQ, [FromQuery] string passQ)
        {
            //string userName = userQ;
            string pass = passQ;

            var user = _context.Usuario.FirstOrDefault(u => u.Usuario1 == userQ);

            if (user == null)
            {
                return BadRequest();
            }

            if (!_passHash.Validate(passQ, user.HashSalt, user.Password))
            {
                return BadRequest();
            }

            //var usuario = (from us in _context.Usuario
            //               where us.Usuario1 == userName
            //               select us);
            return Ok(user);

        }

        //[HttpPost]
        //public IActionResult Registrar([FromBody] Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Usuario.Add(usuario);
        //        _context.SaveChanges();

        //        return Ok(usuario);
        //    }
        //    else
        //    {
        //        return BadRequest();

        //    }
        //}
    }
}