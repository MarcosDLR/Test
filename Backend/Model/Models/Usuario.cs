﻿using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        public Role IdRoleNavigation { get; set; }
        public ICollection<Actividad> Actividad { get; set; }
    }
}
