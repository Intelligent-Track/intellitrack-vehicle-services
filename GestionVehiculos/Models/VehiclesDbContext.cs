using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionVehiculos.Models;

public partial class VehiclesDbContext : DbContext
{
    public VehiclesDbContext()
    {
    }

    public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.HistorialAveriosMecanicos)
                .HasMaxLength(45)
                .HasColumnName("HistorialAverios/Mecanicos");
            entity.Property(e => e.Modelo).HasMaxLength(45);
            entity.Property(e => e.Tipo).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
