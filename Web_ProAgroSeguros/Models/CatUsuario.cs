using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Web_ProAgroSeguros.Models
{
    public partial class CatUsuario
    {
        public int idUsuario { get; set; }
        public int idEstado { get; set; }
        public string nombre { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string rfc { get; set; }
    }
}
