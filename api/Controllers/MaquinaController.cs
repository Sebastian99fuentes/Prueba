using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Maquina;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/maquina")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinariaRepository _maquinaRepo;

          public MaquinaController( IMaquinariaRepository maquinaRepo)
        {

            _maquinaRepo =  maquinaRepo;
          

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var maquinas = await  _maquinaRepo.GetAllAsync();

             var maquinasDto = maquinas.Select(s => s.ToMaquinaDto());
             
             return Ok(maquinasDto);
        } 

         [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        { 
            var maquina = await _maquinaRepo.GetByIdAsync(id);

            if(maquina== null)
            {
                return NotFound();
            }
            return Ok(maquina.ToMaquinaDto());  

        }

         [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaquinaRequestDto  maquinakDto) 
        { 
            var maquinaModel = maquinakDto.ToMaquinaFromCreateDto();
            await _maquinaRepo.CreateAsync(maquinaModel);
         
            return CreatedAtAction(nameof(GetById), new {id = maquinaModel.Id}, maquinaModel.ToMaquinaDto());

        }

        [HttpPut]
      [Route("{id}")]
      public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateMaquinaRequest UpdateDto)
      {
        var maquinaModel = await _maquinaRepo.UpdateAsync(id,UpdateDto);

        if (maquinaModel == null)
        {
            return NotFound();
        } 

        return Ok(maquinaModel.ToMaquinaDto());

      } 

      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> Delete ([FromRoute] int id)
      {
        var maquinaModel = await _maquinaRepo.DeleteAsync(id);
        if (maquinaModel == null)
        {
            return NotFound();
        }
        return NoContent();
    
      }

        
    }
}