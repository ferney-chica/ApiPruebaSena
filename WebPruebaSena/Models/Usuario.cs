using System;
using System.Collections.Generic;

#nullable disable

namespace WebPruebaSena.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombres { get; set; }
        public string UsuarioApellidos { get; set; }
        public string UsuarioTelefono { get; set; }
        public string UsuarioDireccion { get; set; }
        public string UsuarioTipoId { get; set; }
        public string UsuarioContrasena { get; set; }
        public string UsuarioEmail { get; set; }
        public decimal UsuarioRol { get; set; }
    }
}
