using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

/// <summary>Configuración de la tabla Partidos (las llaves).</summary>
public class PartidoConfiguracion : IEntityTypeConfiguration<Partido>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Partido> b)
    {
        b.HasOne(p => p.Torneo)
            .WithMany(t => t.Partidos)
            .HasForeignKey(p => p.TorneoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Un partido apunta tres veces a Equipo, así que cada relación se declara aparte.
        b.HasOne(p => p.EquipoA).WithMany().HasForeignKey(p => p.EquipoAId).OnDelete(DeleteBehavior.ClientSetNull);
        b.HasOne(p => p.EquipoB).WithMany().HasForeignKey(p => p.EquipoBId).OnDelete(DeleteBehavior.ClientSetNull);
        b.HasOne(p => p.Ganador).WithMany().HasForeignKey(p => p.GanadorId).OnDelete(DeleteBehavior.ClientSetNull);

        // En un torneo no puede haber dos partidos en la misma ronda y posición.
        b.HasIndex(p => new { p.TorneoId, p.Ronda, p.Posicion }).IsUnique();
    }
}
