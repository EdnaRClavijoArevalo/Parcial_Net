using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
    [Table("dbo.cursos")]
    public class Cursos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCurso{get;set;}

         
        public int idColegio{get;set;}


        public string nombreCurso{get;set;}


        [ForeignKey("idColegio")]
        public Colegios Colegio { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
        public virtual ICollection<CursoMateria> CursoMateria { get; set; }
    }
}
