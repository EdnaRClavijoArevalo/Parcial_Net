using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace colegio7.Models
{
    public class Barrios
    {
            public int idBarrio { get; set; }

            [Required]
            public string nombreBarrio { get; set; }
        
    }
}