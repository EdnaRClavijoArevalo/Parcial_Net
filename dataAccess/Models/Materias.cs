using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
     [Table("dbo.Materias")]
   public class Materias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMateria { get; set; }

        [StringLength(100)]
        public string nombreMateria { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; }

        public ICollection<CursoMateria> CursoMateria { get; set; }
    }
}
