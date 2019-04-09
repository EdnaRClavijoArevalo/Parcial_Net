using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
     [Table("dbo.Barrio")]
    public class Barrios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBarrio { get; set; }

        [StringLength(100)]
        public string nombreBarrio { get; set; }

        public ICollection<Estudiantes> Cursos { get; set; }
    }
}
