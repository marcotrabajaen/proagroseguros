using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_ProAgroSeguros.ViewModels
{
    public class Login
    {
        [Required]
        public string RFC { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}
