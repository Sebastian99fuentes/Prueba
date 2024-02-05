using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Maquina
{
    public class MaquinaDto
    {
          public int Id{ get; set; }

        public string Serie { get; set; } = string.Empty;
         public string Descripcion { get; set; } = string.Empty;
        public bool EstadoMaquinaria { get; set; } 

     
    }
}