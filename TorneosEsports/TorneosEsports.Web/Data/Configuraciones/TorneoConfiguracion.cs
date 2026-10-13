using TorneosEsports.Web.Data.Semilla;
using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

/// <summary>Configuración de la tabla Torneos (catálogo 2).</summary>
public class TorneoConfiguracion : IEntityTypeConfiguration<Torneo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Torneo> b)
    {
        b.Property(t => t.Juego).HasMaxLength(80).IsRequired();
        b.Property(t => t.Formato).HasMaxLength(80).IsRequired();
        // Monto en colones: decimal(12,2) en SQL Server.
        b.Property(t => t.PrecioInscripcion).HasPrecision(12, 2);

        // El estado se guarda como texto ("Abierto", "EnJuego"...) para que sea legible en la BD.
        b.Property(t => t.Estado).HasConversion<string>().HasMaxLength(20);

        // Un evento tiene muchos torneos. Restrict: no se borra un evento que tiene torneos.
        b.HasOne(t => t.Evento)
            .WithMany(e => e.Torneos)
            .HasForeignKey(t => t.EventoId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasIndex(t => new { t.EventoId, t.Juego });
        b.HasData(DatosSemilla.Torneos);
    }
}
