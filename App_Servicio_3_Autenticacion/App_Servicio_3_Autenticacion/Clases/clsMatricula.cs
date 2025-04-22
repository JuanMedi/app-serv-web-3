using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using App_Servicio_3_Autenticacion.Models;

namespace App_Servicio_3_Autenticacion.Clases
{
    public class clsMatricula
    {
        private DBExamenEntities dbMatricula = new DBExamenEntities();
        public Matricula matricula { get; set; }
        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbMatricula.Matriculas.Add(matricula);
                dbMatricula.SaveChanges();
                return "Matricula insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la matricula: " + ex.Message;
            }
        }

        public Matricula ConsultarXEstudiante(string documento, string semestre)
        {
            try
            {
                var matriculaEncontrada = (from m in dbMatricula.Matriculas
                                           join e in dbMatricula.Estudiantes on m.idEstudiante equals e.idEstudiante
                                           where e.Documento == documento && m.SemestreMatricula == semestre
                                           select m).FirstOrDefault();

                return matriculaEncontrada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar matrícula: " + ex.Message);
            }
        }

        public Matricula Consultar(int idmatricula)
        {
            try
            {
                Matricula ma = dbMatricula.Matriculas.Where(m => m.idMatricula == matricula.idMatricula).FirstOrDefault();
                return ma;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar matrícula: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Matricula ma = Consultar(matricula.idMatricula);
            if (ma == null)
            {
                return "Matricula no existe";
            }
            dbMatricula.Matriculas.AddOrUpdate(matricula);
            dbMatricula.SaveChanges();
            return "Matricula actualizada correctamente";
        }

        public string Borrar()
        {
            Matricula ma = Consultar(matricula.idMatricula);
            if (ma == null)
            {
                return "Vehiculo no existe";
            }
            dbMatricula.Matriculas.Remove(ma);
            dbMatricula.SaveChanges();
            return "Vehiculo eliminado correctamente";
        }

    }
}