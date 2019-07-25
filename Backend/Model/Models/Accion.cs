using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Accion
    {
        //public Accion()
        //{
        //    Actividad = new HashSet<Actividad>();
        //}

        public int Id { get; set; }
        public string Nombre { get; set; }

        //public ICollection<Actividad> Actividad { get; set; }
    }
}
