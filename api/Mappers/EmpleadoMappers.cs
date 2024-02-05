using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Empleados;
using api.Models;

namespace api.Mappers
{
    public  static class EmpleadoMappers
    {
        
        public static EmpleadosDto ToEmpleadoDto(this Empleados empleadoModel)
        {
            return new EmpleadosDto
            {
                Id = empleadoModel.Id,
                Nombre = empleadoModel.Nombre,
                Cargo = empleadoModel.Cargo,
                Cedula = empleadoModel.Cedula,
                Area = empleadoModel.Area
            };
        }

         public static Empleados ToEmpleadoFromCreateDto(this CreateEmpleadoRequestDto empleadoDto)
        {
            return new Empleados
            {
                  
                Nombre = empleadoDto.Nombre,
                Cargo = empleadoDto.Cargo,
                Cedula = empleadoDto.Cedula,
                Area = empleadoDto.Area
                

            };
        }
    }
}