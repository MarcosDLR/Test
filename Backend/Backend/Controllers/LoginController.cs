using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contexts.Data;
using Model.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly TestDbContext _context;

        public LoginController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet("login")]
        public IActionResult Validar([FromQuery] string userQ, [FromQuery] string passQ)
        {
            string userName = userQ;
            string pass = passQ;

            //var usuario = (from us in _context.Usuario
            //               where us.Usuario1 == userName
            //               select us);

            var user = _context.Usuario.FirstOrDefault(u => u.Usuario1 == userName && u.Password == pass);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
            
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