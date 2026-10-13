using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

/// <summary>Configuración de la tabla IntegrantesEquipo.</summary>
public class IntegranteEquipoConfiguracion : IEntityTypeConfiguration<IntegranteEquipo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<IntegranteEquipo> b)
    {
        b.Property(i => i.Nombre).HasMaxLength(100).IsRequired();
        b.Property(i => i.Nick).HasMaxLength(40).IsRequired();
        b.Property(i => i.Correo).HasMaxLength(120).IsRequired();

        b.HasOne(i => i.Equipo)
            .WithMany(e => e.Integrantes)
            .HasForeignKey(i => i.EquipoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
