using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Empleados;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EmpleadoRepository : IempleadosRepository
    {
         private readonly ApplicationDBContext _context;
            public EmpleadoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public  async Task<Empleados> CreateAsync(Empleados empleadoModel)
        {
             await _context.empleado.AddAsync(empleadoModel);
            await _context.SaveChangesAsync();
            return empleadoModel;
        }

        public async Task<Empleados?> DeleteAsync(int id)
        {
            var empleadoModel =await _context.empleado.FirstOrDefaultAsync(x => x.Id ==id);

           if (empleadoModel== null)
           {
            return null;
           }
           _context.empleado.Remove(empleadoModel);
           await _context.SaveChangesAsync();

           return empleadoModel;
        }

        public async Task<List<Empleados>> GetAllAsync()
        {
            return await _context.empleado.ToListAsync();
        }

        public async Task<Empleados?> GetByIdAsync(int id)
        {
             return  await _context.empleado.FindAsync(id);
        }

        public  async Task<Empleados?> UpdateAsync(int id, UpdateEmpleadoRequest empleadoDto)
        {
             var existEmpleado = await _context.empleado.FirstOrDefaultAsync( x=> x.Id ==id);
            if(existEmpleado == null)
            {
                return null;
            }

            existEmpleado.Nombre = empleadoDto.Nombre;
            existEmpleado.Cargo = empleadoDto.Cargo;
            existEmpleado.Cedula = empleadoDto.Cedula;
            existEmpleado.Area = empleadoDto.Area;

         await _context.SaveChangesAsync();

           return existEmpleado;

        }
    }
}