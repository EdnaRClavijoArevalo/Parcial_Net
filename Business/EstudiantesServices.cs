using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccess.Models;
using dataAccess;
using System.Data.Entity;
using System.Linq;
using Business.Interfaces;


namespace Business
{
    public class EstudiantesServices : IEstudiantesServices
    {
        public bool validarMinimos( int idEstudiante) 
        {
            int conteo  = 0;
            using (ColegioEntities context = new ColegioEntities())
            {
                Estudiantes estudiante = context.Estudiantes.Where(c => c.idEstudiante == idEstudiante).ToList().FirstOrDefault();

                conteo = context.Estudiantes.Where(c => c.idCurso == estudiante.idCurso).ToList().Count();

            }


            return conteo > 2;
        }
    }
}
