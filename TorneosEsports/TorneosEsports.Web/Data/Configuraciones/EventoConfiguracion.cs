using TorneosEsports.Web.Data.Semilla;
using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

/// <summary>Configuración de la tabla Eventos (catálogo 1).</summary>
public class EventoConfiguracion : IEntityTypeConfiguration<Evento>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Evento> b)
    {
        b.Property(e => e.Nombre).HasMaxLength(120).IsRequired();
        b.Property(e => e.Sede).HasMaxLength(120).IsRequired();
        b.Property(e => e.ImagenUrl).HasMaxLength(300);
        b.Property(e => e.Descripcion).HasMaxLength(1000);
        // Monto en colones: decimal(12,2) en SQL Server.
        b.Property(e => e.PrecioPase).HasPrecision(12, 2);
        b.HasIndex(e => e.Fecha);
        b.HasData(DatosSemilla.Eventos);
    }
}
