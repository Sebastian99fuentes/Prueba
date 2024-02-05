using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Empleados;
using api.Models;

namespace api.Interfaces
{
    public interface IempleadosRepository
    {
       Task<List<Empleados>> GetAllAsync();

        Task<Empleados?> GetByIdAsync(int id);

        Task<Empleados> CreateAsync(Empleados empleadoModel);

        Task<Empleados?> UpdateAsync(int id, UpdateEmpleadoRequest empleadoDto);

        Task<Empleados?> DeleteAsync(int id);
    }
}