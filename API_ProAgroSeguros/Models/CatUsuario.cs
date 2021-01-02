using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class CatUsuario
    {
        public CatUsuario()
        {
            CatUsuarioEstados = new HashSet<CatUsuarioEstado>();
        }

        public int IdUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Rfc { get; set; }

        [NotMapped]
        public virtual ICollection<CatUsuarioEstado> CatUsuarioEstados { get; set; }
    }
}
