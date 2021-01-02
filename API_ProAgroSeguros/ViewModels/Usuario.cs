using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Rfc { get; set; }
    }
}
