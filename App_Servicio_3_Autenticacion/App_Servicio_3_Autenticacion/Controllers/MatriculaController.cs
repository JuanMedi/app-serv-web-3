using App_Servicio_3_Autenticacion.Clases;
using App_Servicio_3_Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_Servicio_3_Autenticacion.Controllers
{
    [RoutePrefix("api/Matricula")]
    [Authorize]
    public class MatriculaController : ApiController
    {

        [HttpGet]
        [Route("ConsultarXEstudiante")]
        public Matricula ConsultarXEstudiante(string documento, string semestre)
        {
            clsMatricula clsMatricula = new clsMatricula();
            return clsMatricula.ConsultarXEstudiante(documento, semestre); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Matricula matricula)
        {
            clsMatricula clsMatricula = new clsMatricula();
            clsMatricula.matricula = matricula;
            return clsMatricula.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Matricula matricula)
        {
            clsMatricula clsMatricula = new clsMatricula();
            clsMatricula.matricula = matricula;
            return clsMatricula.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idmatricula)
        {
            clsMatricula clsMatricula = new clsMatricula();
            return clsMatricula.Borrar(idmatricula);
        }
    }
}
