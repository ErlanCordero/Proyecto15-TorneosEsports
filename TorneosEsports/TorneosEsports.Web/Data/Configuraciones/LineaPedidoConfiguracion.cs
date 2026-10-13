using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

// Configuración base de la tabla; se puede ajustar aquí cuando se trabaje ese módulo.
/// <summary>Configuración de la tabla LineasPedido.</summary>
public class LineaPedidoConfiguracion : IEntityTypeConfiguration<LineaPedido>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<LineaPedido> b)
    {
        b.Property(l => l.Descripcion).HasMaxLength(150).IsRequired();
        b.Property(l => l.Tipo).HasConversion<string>().HasMaxLength(20);
        // Monto en colones: decimal(12,2) en SQL Server.
        b.Property(l => l.PrecioUnitario).HasPrecision(12, 2);
    }
}
