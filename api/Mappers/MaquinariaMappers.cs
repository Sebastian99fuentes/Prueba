using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Maquina;
using api.Models;

namespace api.Mappers
{
    public static class MaquinariaMappers
    {
        public static MaquinaDto ToMaquinaDto(this Maquinaria MaquinariaModel)
        {
            return new MaquinaDto
            {
                Id = MaquinariaModel.Id,
                Serie = MaquinariaModel.Serie,
                Descripcion = MaquinariaModel.Descripcion,
                EstadoMaquinaria = MaquinariaModel.EstadoMaquinaria

            };
        }

         public static Maquinaria ToMaquinaFromCreateDto(this CreateMaquinaRequestDto MaquinariaModel)
        {
            return new Maquinaria
            {
                  
                  Serie = MaquinariaModel.Serie,
                Descripcion = MaquinariaModel.Descripcion,
                 EstadoMaquinaria = MaquinariaModel.EstadoMaquinaria
                

            };
        }
    }
}