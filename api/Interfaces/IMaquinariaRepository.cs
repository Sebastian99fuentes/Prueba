using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Maquina;
using api.Models;

namespace api.Interfaces
{
    public interface IMaquinariaRepository
    {
        Task<List<Maquinaria>> GetAllAsync();

        Task<Maquinaria?> GetByIdAsync(int id);

        Task<Maquinaria> CreateAsync(Maquinaria maquinariaModel);

        Task<Maquinaria?> UpdateAsync(int id, UpdateMaquinaRequest maquinariaDto);

        Task<Maquinaria?> DeleteAsync(int id);
    }
}