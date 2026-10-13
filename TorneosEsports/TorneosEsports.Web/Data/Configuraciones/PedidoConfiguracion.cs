using TorneosEsports.Web.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneosEsports.Web.Data.Configuraciones;

// Configuración base de la tabla; se puede ajustar aquí cuando se trabaje ese módulo.
/// <summary>Configuración de la tabla Pedidos.</summary>
public class PedidoConfiguracion : IEntityTypeConfiguration<Pedido>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Pedido> b)
    {
        b.Property(p => p.UsuarioId).IsRequired();
        // Monto en colones: decimal(12,2) en SQL Server.
        b.Property(p => p.Total).HasPrecision(12, 2);
        b.Property(p => p.Estado).HasConversion<string>().HasMaxLength(20);

        b.HasMany(p => p.Lineas)
            .WithOne(l => l.Pedido)
            .HasForeignKey(l => l.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Uno a uno: cada pedido tiene a lo sumo un pago.
        b.HasOne(p => p.Pago)
            .WithOne(pg => pg.Pedido)
            .HasForeignKey<Pago>(pg => pg.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(p => p.UsuarioId);
    }
}
