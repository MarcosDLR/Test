using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public partial class Usuario
    {
        //public Usuario()
        //{
        //    Actividad = new HashSet<Actividad>();
        //}

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Column("Usuario")]
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        [Column("IdRole")]
        public int? RoleId { get; set; }
        [Column("HashSalt")]
        public string HashSalt { get; set; }
        public Role Role { get; set; }

        //public Role IdRoleNavigation { get; set; }
        //public ICollection<Actividad> Actividad { get; set; }
    }
}
