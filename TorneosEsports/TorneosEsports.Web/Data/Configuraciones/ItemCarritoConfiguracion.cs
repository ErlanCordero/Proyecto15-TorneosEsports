using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

// Configuración base de la tabla; se puede ajustar aquí cuando se trabaje ese módulo.
/// <summary>Configuración de la tabla ItemsCarrito.</summary>
public class ItemCarritoConfiguracion : IEntityTypeConfiguration<ItemCarrito>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ItemCarrito> b)
    {
        b.Property(i => i.UsuarioId).IsRequired();
        b.Property(i => i.Descripcion).HasMaxLength(150).IsRequired();
        b.Property(i => i.Tipo).HasConversion<string>().HasMaxLength(20);
        // Monto en colones: decimal(12,2) en SQL Server.
        b.Property(i => i.PrecioUnitario).HasPrecision(12, 2);
        b.HasIndex(i => i.UsuarioId);
    }
}
