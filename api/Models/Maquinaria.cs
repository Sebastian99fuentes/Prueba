using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Maquinaria
    {

     public int Id { get; set; } 
    public string Serie { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EstadoMaquinaria { get; set; } 
    
      public List<Empleados> Empleadomaquina { get; set; } = []; 
    }

}