using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

// Configuración base de la tabla; se puede ajustar aquí cuando se trabaje ese módulo.
/// <summary>Configuración de la tabla Pagos.</summary>
public class PagoConfiguracion : IEntityTypeConfiguration<Pago>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Pago> b)
    {
        b.Property(p => p.Referencia).HasMaxLength(80);
        b.Property(p => p.Mensaje).HasMaxLength(200);
    }
}
