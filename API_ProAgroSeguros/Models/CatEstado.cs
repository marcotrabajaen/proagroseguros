using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class CatEstado
    {
        public CatEstado()
        {
            CatGeorreferencia = new HashSet<CatGeorreferencia>();
            CatUsuarioEstados = new HashSet<CatUsuarioEstado>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Acronimo { get; set; }

        [NotMapped]
        public virtual ICollection<CatGeorreferencia> CatGeorreferencia { get; set; }
        [NotMapped]
        public virtual ICollection<CatUsuarioEstado> CatUsuarioEstados { get; set; }
    }
}
