using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class CatGeorreferencia
    {
        public int IdGeorreferencias { get; set; }
        public int? IdEstado { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        [NotMapped]
        public virtual CatEstado IdEstadoNavigation { get; set; }
    }
}
