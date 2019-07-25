using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Role
    {
        //public Role()
        //{
        //    Usuario = new HashSet<Usuario>();
        //}

        public int Id { get; set; }
        public string Nombre { get; set; }

        //public ICollection<Usuario> Usuario { get; set; }
    }
}
