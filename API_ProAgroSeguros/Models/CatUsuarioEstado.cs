using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class CatUsuarioEstado
    {
        public int IdUsuarioEstado { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEstado { get; set; }

        [NotMapped]
        public virtual CatEstado IdEstadoNavigation { get; set; }
        [NotMapped]
        public virtual CatUsuario IdUsuarioNavigation { get; set; }
    }
}
