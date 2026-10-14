using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

/// <summary>Configuración de la tabla Equipos.</summary>
public class EquipoConfiguracion : IEntityTypeConfiguration<Equipo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Equipo> b)
    {
        b.Property(e => e.Nombre).HasMaxLength(60).IsRequired();

        b.HasOne(e => e.Torneo)
            .WithMany(t => t.Equipos)
            .HasForeignKey(e => e.TorneoId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(e => e.Capitan)
            .WithMany()
            .HasForeignKey(e => e.CapitanId)
            .OnDelete(DeleteBehavior.Restrict);

        // No puede haber dos equipos con el mismo nombre en el mismo torneo.
        b.HasIndex(e => new { e.TorneoId, e.Nombre }).IsUnique();
    }
}
