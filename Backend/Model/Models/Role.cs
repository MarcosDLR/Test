using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("SYS_Role")]
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
