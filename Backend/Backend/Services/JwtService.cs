using Contexts.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class JwtService
    {
        private readonly TestDbContext _context;
        private readonly PassHashService _passHash;
        private readonly IConfiguration _configuration;

        public JwtService(TestDbContext context, PassHashService passHash, IConfiguration configuration)
        {
            _context = context;
            _passHash = passHash;
            _configuration = configuration;
        }

        public string CreateToken(string userQ)
        {
            var user = _context.Usuario.SingleOrDefault(u => u.Usuario1 == userQ);

            //if (user == null)
            //{
            //    return null;
            //}


            //if (!_passHash.Validate(passQ, user.HashSalt, user.Password))
            //{
            //    return null;
            //}

            //var secretKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = "https://localhost:5001",              // quien envia, no lo usaremos ahora
            //    Audience = "https://localhost:5001",            // quien recibe, no lo usaremos ahora
            //    //IssuedAt = DateTime.UtcNow,
            //    //NotBefore = DateTime.UtcNow,
            //    Expires = DateTime.UtcNow.AddMinutes(30),
            //    //Subject = new ClaimsIdentity(new List<Claim> {
            //    //        new Claim("Id", user.Id.ToString()),
            //    //        new Claim("role", user.RoleId.ToString())
            //    //    }),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            //};


            //var jwtTokenHandler = new JwtSecurityTokenHandler();
            //var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            //var token = jwtTokenHandler.WriteToken(jwtToken);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sflkadjhfjhueh#asdkfjh@laksjdfksk.askdfhm,aksdhfsdf"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;

            //return token;
        }

    }
}
