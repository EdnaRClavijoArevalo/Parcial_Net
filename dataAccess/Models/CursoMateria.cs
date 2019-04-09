using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
     [Table("dbo.CursoMateria")]
    public class CursoMateria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCursoMateria { get; set; }

        public int idCurso { get; set; }

        public int idMateria { get; set; }

        [ForeignKey("idCurso")]
        public Cursos Cursos { get; set; }

        [ForeignKey("idMateria")]
        public Materias Materias { get; set; }
    }
}
