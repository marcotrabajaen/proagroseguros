using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ProAgroSeguros.Models
{
    public class Credencial
    {
        [Required]
        public string RFC { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}
