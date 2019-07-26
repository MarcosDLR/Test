using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Usuario1 { get; set; }
        public int? RoleId { get; set; }
    }
}
