namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Ciclo de vida de un torneo: Abierto → Cerrado → EnJuego → Finalizado.
/// </summary>
public enum EstadoTorneo
{
    /// <summary>Acepta inscripciones de equipos.</summary>
    Abierto = 0,

    /// <summary>Ya no acepta inscripciones; paso previo a generar las llaves.</summary>
    Cerrado = 1,

    /// <summary>Las llaves están generadas y se registran resultados.</summary>
    EnJuego = 2,

    /// <summary>La final tiene ganador: el torneo tiene campeón.</summary>
    Finalizado = 3,
}

/// <summary>Textos en español de <see cref="EstadoTorneo"/> para mostrar en las vistas.</summary>
public static class EstadoTorneoExtensions
{
    /// <summary>Devuelve el nombre del estado tal como lo ve el usuario.</summary>
    /// <param name="estado">Estado del torneo.</param>
    /// <returns>Texto en español, por ejemplo «En juego».</returns>
    public static string Nombre(this EstadoTorneo estado) => estado switch
    {
        EstadoTorneo.Abierto => "Inscripciones abiertas",
        EstadoTorneo.Cerrado => "Inscripciones cerradas",
        EstadoTorneo.EnJuego => "En juego",
        EstadoTorneo.Finalizado => "Finalizado",
        _ => estado.ToString(),
    };

    /// <summary>Clase de color de Bootstrap para la etiqueta del estado.</summary>
    /// <param name="estado">Estado del torneo.</param>
    /// <returns>Una clase como «bg-success».</returns>
    public static string ClaseCss(this EstadoTorneo estado) => estado switch
    {
        EstadoTorneo.Abierto => "bg-success",
        EstadoTorneo.Cerrado => "bg-secondary",
        EstadoTorneo.EnJuego => "bg-warning text-dark",
        EstadoTorneo.Finalizado => "bg-dark",
        _ => "bg-light text-dark",
    };
}
