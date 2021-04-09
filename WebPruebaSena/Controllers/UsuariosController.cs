using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaSena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.BD_PruebaContext db= new Models.BD_PruebaContext())
            {
                var listaUsuarios = (
                        from d in db.Usuarios
                        select d
                    ).ToList();

                return Ok(listaUsuarios);
            }

        }

        [HttpPost] //Insertar
        public ActionResult Post([FromBody] Models.Request.UsuariosRequest model)
        {
            using (Models.BD_PruebaContext db = new Models.BD_PruebaContext())
            {
                Models.Usuario oUsuario = new Models.Usuario();
                oUsuario.UsuarioId = model.id;
                oUsuario.UsuarioNombres = model.nombres;
                oUsuario.UsuarioApellidos = model.apellidos;
                oUsuario.UsuarioTelefono = model.telefono;
                oUsuario.UsuarioDireccion = model.direccion;

                db.Usuarios.Add(oUsuario);
                db.SaveChanges();
            }

            return Ok();
        }


        [HttpGet("{id}")] //Encontrar un usuario por id
        public ActionResult Get(int id)
        {
            using (Models.BD_PruebaContext db = new Models.BD_PruebaContext())
            {
                var usuario = (from usu in db.Usuarios
                                where usu.UsuarioId == id
                                select usu).ToList();
                return Ok(usuario);
            }
        }


        [HttpPut] //Editar
        public ActionResult Put([FromBody] Models.Request.UsuariosRequest model)
        {
            using (Models.BD_PruebaContext db = new Models.BD_PruebaContext())
            {
                Models.Usuario oUsuario = db.Usuarios.Find(model.id);
               
                oUsuario.UsuarioNombres = model.nombres;
                oUsuario.UsuarioApellidos = model.apellidos;
                oUsuario.UsuarioTelefono = model.telefono;
                oUsuario.UsuarioDireccion = model.direccion;

                db.Entry(oUsuario).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }


        [HttpDelete] //Eliminar
        public ActionResult Delete([FromBody] Models.Request.UsuariosRequest model)
        {
            using (Models.BD_PruebaContext db = new Models.BD_PruebaContext())
            {
                Models.Usuario oUsuario = db.Usuarios.Find(model.id);

                db.Usuarios.Remove(oUsuario);
                db.SaveChanges();
            }

            return Ok();
        }

    }
}
