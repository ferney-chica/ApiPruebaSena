using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaSena.Models.Request
{
    public class UsuariosRequest
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string tipoId { get; set; }
        public string contrasena { get; set; }
        public string email { get; set; }
        public string rol { get; set; }
    }
}
