using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ProAgroSeguros.Models
{
    public class Ubicacion
    {
        public string Nombre { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}