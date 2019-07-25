using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contexts.Data;
using Model.Models;

namespace Backend.Controllers
{
    public class LoginController : Controller
    {

        private readonly TestDbContext _context;

        public LoginController(TestDbContext context)
        {
            _context = context;
        }

        public IActionResult Prueba()
        {
            return View();
        }

        [HttpGet("validar")]
        public IActionResult Validar(string _userName, string _pass)
        {
            string userName = _userName;
            string pass = _pass;

            //var usuario = (from us in _context.Usuario
            //               where us.Usuario1 == userName
            //               select us.Nombre);

            var user = _context.Usuario.FirstOrDefault(u => u.Usuario1 == userName && u.Password == pass);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Usuario usuario)
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
    }
}