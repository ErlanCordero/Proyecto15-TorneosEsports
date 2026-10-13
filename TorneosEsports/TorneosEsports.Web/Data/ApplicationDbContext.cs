using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TorneosEsports.Web.Models.Entidades;

namespace TorneosEsports.Web.Data
{
    /// <summary>
    /// Contexto de Entity Framework: une las tablas de Identity (usuarios y roles), la
    /// bitácora y las tablas del proyecto.
    /// </summary>
    /// <remarks>
    /// La configuración de cada tabla no está aquí sino en Data/Configuraciones, una clase
    /// por entidad; así este archivo casi no cambia y se evitan conflictos en Git cuando
    /// cada integrante agrega su parte.
    /// </remarks>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>Crea el contexto con las opciones que inyecta el contenedor (SQL Server y cadena de conexión).</summary>
        /// <param name="options">Opciones del contexto.</param>
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>Bitácora de acciones.</summary>
        public DbSet<BitacoraAccion> BitacoraAcciones { get; set; }

        /// <summary>Catálogo 1: eventos.</summary>
        public DbSet<Evento> Eventos => Set<Evento>();

        /// <summary>Catálogo 2: torneos de cada evento.</summary>
        public DbSet<Torneo> Torneos => Set<Torneo>();

        /// <summary>Equipos inscritos en los torneos.</summary>
        public DbSet<Equipo> Equipos => Set<Equipo>();

        /// <summary>Integrantes de cada equipo.</summary>
        public DbSet<IntegranteEquipo> IntegrantesEquipo => Set<IntegranteEquipo>();

        /// <summary>Partidos de las llaves.</summary>
        public DbSet<Partido> Partidos => Set<Partido>();

        /// <summary>Líneas del carrito de compras.</summary>
        public DbSet<ItemCarrito> ItemsCarrito => Set<ItemCarrito>();

        /// <summary>Pedidos.</summary>
        public DbSet<Pedido> Pedidos => Set<Pedido>();

        /// <summary>Líneas de los pedidos.</summary>
        public DbSet<LineaPedido> LineasPedido => Set<LineaPedido>();

        /// <summary>Pagos de los pedidos.</summary>
        public DbSet<Pago> Pagos => Set<Pago>();

        /// <summary>Arma el modelo: primero las tablas de Identity y luego las configuraciones del proyecto.</summary>
        /// <param name="builder">Constructor del modelo de EF.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Busca y aplica todas las clases IEntityTypeConfiguration<T> de Data/Configuraciones.
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
