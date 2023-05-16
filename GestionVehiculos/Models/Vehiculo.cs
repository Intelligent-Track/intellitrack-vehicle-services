using System;
using System.Collections.Generic;

namespace GestionVehiculos.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string? Modelo { get; set; }

    public int? Placa { get; set; }

    public string? Tipo { get; set; }

    public string? HistorialAveriosMecanicos { get; set; }

    public int? CapacidadVolumen { get; set; }

    public int? CapacidadPeso { get; set; }
}
