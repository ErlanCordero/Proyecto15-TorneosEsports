using TorneosEsports.Web.Models.Entidades;

namespace TorneosEsports.Web.Data.Semilla;

/// <summary>
/// Eventos y torneos de ejemplo que se insertan con la migración (HasData).
/// </summary>
/// <remarks>
/// Se usan objetos anónimos con valores fijos porque HasData exige
/// que los datos no cambien entre una migración y otra (no se puede usar DateTime.Now).
/// </remarks>
public static class DatosSemilla
{
    private static readonly DateTime Creado = new(2026, 10, 9, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>Tres eventos de ejemplo (catálogo 1).</summary>
    public static object[] Eventos =>
    [
        new
        {
            Id = 1, FechaCreacion = Creado,
            Nombre = "LAN Party Arena Heredia 2026",
            Sede = "Centro de convenciones, Heredia",
            Fecha = new DateTime(2026, 11, 21, 9, 0, 0),
            CupoPuestos = 200, PrecioPase = 8000m,
            ImagenUrl = (string?)null,
            Descripcion = (string?)"Dos días de LAN con torneos de Valorant y League of Legends.",
        },
        new
        {
            Id = 2, FechaCreacion = Creado,
            Nombre = "Copa Universitaria de Esports",
            Sede = "Gimnasio universitario, San José",
            Fecha = new DateTime(2026, 11, 28, 10, 0, 0),
            CupoPuestos = 120, PrecioPase = 5000m,
            ImagenUrl = (string?)null,
            Descripcion = (string?)"Equipos universitarios compiten en Counter-Strike 2 y Dota 2.",
        },
        new
        {
            Id = 3, FechaCreacion = Creado,
            Nombre = "Noche LAN de Fin de Año",
            Sede = "Salón comunal, Alajuela",
            Fecha = new DateTime(2026, 12, 5, 16, 0, 0),
            CupoPuestos = 80, PrecioPase = 4000m,
            ImagenUrl = (string?)null,
            Descripcion = (string?)"Cierre del año con torneos de Overwatch 2 y Rainbow Six Siege.",
        },
    ];

    /// <summary>Seis torneos de ejemplo (catálogo 2), dos por evento.</summary>
    public static object[] Torneos =>
    [
        Torneo(1, 1, "Valorant", 16, 25000m, new DateTime(2026, 11, 14, 23, 59, 0)),
        Torneo(2, 1, "League of Legends", 8, 25000m, new DateTime(2026, 11, 14, 23, 59, 0)),
        Torneo(3, 2, "Counter-Strike 2", 8, 20000m, new DateTime(2026, 11, 21, 23, 59, 0)),
        Torneo(4, 2, "Dota 2", 8, 20000m, new DateTime(2026, 11, 21, 23, 59, 0)),
        Torneo(5, 3, "Overwatch 2", 8, 15000m, new DateTime(2026, 11, 28, 23, 59, 0)),
        Torneo(6, 3, "Rainbow Six Siege", 8, 15000m, new DateTime(2026, 11, 28, 23, 59, 0)),
    ];

    private static object Torneo(int id, int eventoId, string juego, int cupo, decimal precio, DateTime cierre) => new
    {
        Id = id, FechaCreacion = Creado,
        EventoId = eventoId,
        Juego = juego,
        Formato = "Eliminación directa 5v5",
        CupoEquipos = cupo,
        PrecioInscripcion = precio,
        CierreInscripciones = cierre,
        Estado = EstadoTorneo.Abierto,
    };
}
