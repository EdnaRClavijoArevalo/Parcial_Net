using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccess.Models
{
    [Table("dbo.colegios")]
    public class Colegios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idColegio { get; set; }

        [StringLength(50)]
        public string NombreColegio { get; set; }

        public ICollection<Cursos> Cursos { get; set; }
    }
}
