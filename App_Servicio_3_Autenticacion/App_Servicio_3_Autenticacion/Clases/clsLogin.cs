using App_Servicio_3_Autenticacion.Models;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace App_Servicio_3_Autenticacion.Clases
{
    public class clsLogin
    {
        private DBExamenEntities dbMatricula = new DBExamenEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {
                Estudiante estudiante = dbMatricula.Estudiantes.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (estudiante == null)
                {
                    loginRespuesta = new LoginRespuesta();
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta = new LoginRespuesta();
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                //Se consulta el usuario con la clave encriptada y el usuario para validar si existe
                Estudiante estudiante = dbMatricula.Estudiantes.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (estudiante == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                //La clave y el usuario son correctos
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            //Si la validación es simple, en este punto se pone el código: if (user = "admin"){ token=...;}else{error;}
            if (ValidarUsuario() && ValidarClave())
            {
                //Si el usuario y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                //Consulta la información del usuario y el perfil
                return from E in dbMatricula.Set<Estudiante>()
                       where E.Usuario == login.Usuario &&
                               E.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = E.Usuario,
                           Autenticado = true,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}