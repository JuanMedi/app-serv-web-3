using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using App_Servicio_3_Autenticacion.Models;

namespace App_Servicio_3_Autenticacion.Clases
{
    public class clsEstudiante
    {

        private DBExamenEntities dbEstudiante = new DBExamenEntities();
        public Estudiante estudiante { get; set; }

        public Estudiante Consultar(string Documento)
        {
            Estudiante es = dbEstudiante.Estudiantes.Where(e => e.Documento == estudiante.Documento).First();
            return es;
        }

        public string Actualizar()
        {
            Estudiante veh = Consultar(estudiante.Documento);
            if (veh == null)
            {
                return "Vehiculo no existe";
            }
            dbEstudiante.Estudiantes.AddOrUpdate(estudiante);
            dbEstudiante.SaveChanges();
            return "Vehiculo actualizado correctamente";
        }

        public string Borrar()
        {
            Estudiante es = Consultar(estudiante.Documento);
            if (es == null)
            {
                return "Vehiculo no existe";
            }
            dbEstudiante.Estudiantes.Remove(es);
            dbEstudiante.SaveChanges();
            return "Vehiculo eliminado correctamente";
        }

    }
}