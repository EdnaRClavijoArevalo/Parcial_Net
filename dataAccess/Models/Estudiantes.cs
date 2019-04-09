using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
    [Table("dbo.estudiantes")]
    public class Estudiantes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudiante { get; set; }

        [StringLength(100)]
        public string numeroIdentificacion { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string apellido { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        public int idBarrio { get; set; }

        public int idCurso { get; set; }

        [Range(0, 6, ErrorMessage = "Deben ser minímo 2 estudiantes, máximo 6 por curso")]
        public int maxRegistros
        {
            get
            {
                int conteo = 0;
                using (ColegioEntities context = new ColegioEntities())
                {

                    conteo = context.Estudiantes.Where(x => x.idCurso == idCurso).ToList().Count();
                }
                return conteo;
            }
        }

 

        [ForeignKey("idBarrio")]
        public Barrios Barrios { get; set; }

        [ForeignKey("idCurso")]
        public Cursos Cursos { get; set; }
    }
}
