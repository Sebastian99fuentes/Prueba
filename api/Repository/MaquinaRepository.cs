using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Maquina;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MaquinaRepository : IMaquinariaRepository
    { 
         private readonly ApplicationDBContext _context;

        
        public MaquinaRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Maquinaria> CreateAsync(Maquinaria maquinariaModel)
        {
            await _context.Maquinaria.AddAsync(maquinariaModel);
            await _context.SaveChangesAsync();
            return maquinariaModel;
        }

        public async Task<Maquinaria?> DeleteAsync(int id)
        {
            var MaquinariaModel =await _context.Maquinaria.FirstOrDefaultAsync(x => x.Id ==id);

           if (MaquinariaModel== null)
           {
            return null;
           }
           _context.Maquinaria.Remove(MaquinariaModel);
           await _context.SaveChangesAsync();

           return MaquinariaModel;
        }

        public async Task<List<Maquinaria>> GetAllAsync()
        {
            return await _context.Maquinaria.Include(c => c.Empleadomaquina).ToListAsync();
        }

        public async Task<Maquinaria?> GetByIdAsync(int id)
        {
            return  await _context.Maquinaria.FindAsync(id);
        }
        

        public  async   Task<Maquinaria?> UpdateAsync(int id, UpdateMaquinaRequest maquinariaDto)
        {
            var existMaquinaria = await _context.Maquinaria.Include(c => c.Empleadomaquina).FirstOrDefaultAsync( x=> x.Id ==id);
            if(existMaquinaria == null)
            {
                return null;
            }

            existMaquinaria.Serie = maquinariaDto.Serie;
            existMaquinaria.Descripcion = maquinariaDto.Descripcion;
            existMaquinaria.EstadoMaquinaria = maquinariaDto.EstadoMaquinaria;
        

         await _context.SaveChangesAsync();

           return existMaquinaria;

        }
    }
}