using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Empleados;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        
        private readonly IempleadosRepository _empleaRepo;

          public EmpleadoController( IempleadosRepository empleaRepo)
        {

            _empleaRepo =  empleaRepo;
          

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var empleado = await  _empleaRepo.GetAllAsync();

             var empleadoDto = empleado.Select(s => s.ToEmpleadoDto());
             
             return Ok(empleadoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        { 
            var empleado = await _empleaRepo.GetByIdAsync(id);

            if(empleado== null)
            {
                return NotFound();
            }
            return Ok(empleado.ToEmpleadoDto());  

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmpleadoRequestDto  empleadoDto) 
        { 
            var empleadoDtoModel = empleadoDto.ToEmpleadoFromCreateDto();
            await _empleaRepo.CreateAsync(empleadoDtoModel);
            return CreatedAtAction(nameof(GetById), new {id = empleadoDtoModel.Id}, empleadoDtoModel.ToEmpleadoDto());

        }


        [HttpPut]
      [Route("{id}")]

      public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateEmpleadoRequest UpdateDto)
      {
        var empleadoModel = await _empleaRepo.UpdateAsync(id,UpdateDto);

        if (empleadoModel == null)
        {
            return NotFound();
        } 

        return Ok(empleadoModel.ToEmpleadoDto());

      } 

      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> Delete ([FromRoute] int id)
      {
        var stockModel = await _empleaRepo.DeleteAsync(id);
        if (stockModel == null)
        {
            return NotFound();
        }

        return NoContent();

       
      }



    }
}