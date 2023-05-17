using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVehiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVehiculos.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly VehiclesDbContext _context;

        public VehiculoRepository(VehiclesDbContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> CreateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<Vehiculo> GetVehiculoAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                throw new Exception($"No se encontró ningún vehículo con el ID {id}");
            }
            return vehiculo;
        }

        public IEnumerable<Vehiculo> GetVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public async Task<bool> UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehiculoAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return false;
            }
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
