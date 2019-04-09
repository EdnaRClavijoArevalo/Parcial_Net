using dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dataAccess
{
    public class ColegioEntities : DbContext
    {
        public ColegioEntities()
            : base (ConfigurationManager.ConnectionStrings["bdColegio"].ToString())
        { }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Colegios> Colegios { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Barrios> Barrios { get; set; }
        public DbSet<CursoMateria> CursoMateria { get; set; }
        public DbSet<Materias> Materias { get; set; }

    }
}
