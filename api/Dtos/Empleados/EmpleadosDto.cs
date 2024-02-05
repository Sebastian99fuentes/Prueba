using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Empleados
{
    public class EmpleadosDto
    {
          public int Id{ get; set; }

         public string Nombre {get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

          public string Area { get; set; } = string.Empty;

    }
}