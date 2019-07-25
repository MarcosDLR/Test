using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Actividad
    {
        public int Id { get; set; }
        public int? IdUsuarioAdmin { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdAccion { get; set; }

        //public Accion IdAccionNavigation { get; set; }
        //public Usuario IdUsuarioAdminNavigation { get; set; }
    }
}
