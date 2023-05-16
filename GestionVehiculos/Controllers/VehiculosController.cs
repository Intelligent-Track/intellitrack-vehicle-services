using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionVehiculos.Models;
using GestionVehiculos.Repositories;

namespace GestionVehiculos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculosController(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _vehiculoRepository.GetVehiculoAsync(id);
            if (vehiculo is null)
            {
                return NotFound();
            }
            return vehiculo;
        }

        [HttpGet("getall")]
        public IEnumerable<Vehiculo> GetVehiculos()
        {
            return _vehiculoRepository.GetVehiculos();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Vehiculo>> CreateVehiculo(Vehiculo vehiculo)
        {
           
            await _vehiculoRepository.CreateVehiculoAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<Vehiculo>> UpdateVehiculo(Vehiculo vehiculo)
        {
            await _vehiculoRepository.UpdateVehiculoAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            await _vehiculoRepository.DeleteVehiculoAsync(id);
            return Ok();
        }
    }
}
