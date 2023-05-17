using System;
using GestionVehiculos.Models;
namespace GestionVehiculos.Repositories
{
	public interface IVehiculoRepository
	{
        Task<Vehiculo> CreateVehiculoAsync(Vehiculo vehiculo);
        Task<Vehiculo> GetVehiculoAsync(int id);
        IEnumerable<Vehiculo> GetVehiculos();
        Task<bool> UpdateVehiculoAsync(Vehiculo vehiculo);
        Task<bool> DeleteVehiculoAsync(int id);
    }
}

