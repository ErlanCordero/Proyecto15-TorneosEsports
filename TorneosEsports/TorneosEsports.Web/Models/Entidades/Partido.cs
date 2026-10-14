namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Un partido de las llaves (bracket) de un torneo de eliminación directa.
/// </summary>
/// <remarks>
/// Cada partido se ubica por su <see cref="Ronda"/> (1 es la primera)
/// y su <see cref="Posicion"/> dentro de la ronda (desde 0). Con esos dos números se sabe a
/// qué partido pasa el ganador: ronda + 1, posición / 2.
/// </remarks>
public class Partido : EntidadBase
{
    /// <summary>Llave foránea del torneo.</summary>
    public int TorneoId { get; set; }

    /// <summary>Torneo al que pertenece.</summary>
    public Torneo? Torneo { get; set; }

    /// <summary>Número de ronda: 1 es la primera y la última es la final.</summary>
    public int Ronda { get; set; }

    /// <summary>Posición del partido dentro de su ronda, empezando en 0.</summary>
    public int Posicion { get; set; }

    /// <summary>Equipo del lado A; nulo mientras no se conoce.</summary>
    public int? EquipoAId { get; set; }

    /// <summary>Equipo del lado A (navegación).</summary>
    public Equipo? EquipoA { get; set; }

    /// <summary>Equipo del lado B; nulo mientras no se conoce.</summary>
    public int? EquipoBId { get; set; }

    /// <summary>Equipo del lado B (navegación).</summary>
    public Equipo? EquipoB { get; set; }

    /// <summary>Equipo ganador; nulo mientras no hay resultado.</summary>
    public int? GanadorId { get; set; }

    /// <summary>Equipo ganador (navegación).</summary>
    public Equipo? Ganador { get; set; }

    /// <summary>Verdadero si el equipo pasó sin jugar porque no tenía rival (bye).</summary>
    public bool EsBye { get; set; }

    /// <summary>Fecha en que se registró el resultado.</summary>
    public DateTime? FechaResultado { get; set; }

    /// <summary>El partido ya tiene ganador.</summary>
    public bool TieneGanador => GanadorId.HasValue;

    /// <summary>Tiene sus dos equipos y todavía no tiene ganador.</summary>
    public bool ListoParaJugar => EquipoAId.HasValue && EquipoBId.HasValue && !GanadorId.HasValue;

    /// <summary>Posición del partido de la ronda siguiente al que pasa el ganador.</summary>
    public int PosicionSiguiente => Posicion / 2;

    /// <summary>El ganador entra como equipo A en el siguiente partido si la posición es par.</summary>
    public bool GanadorVaComoEquipoA => Posicion % 2 == 0;

    /// <summary>Registra el ganador del partido.</summary>
    /// <param name="ganadorId">Id de uno de los dos equipos del partido.</param>
    /// <param name="fecha">Fecha del resultado.</param>
    /// <exception cref="InvalidOperationException">Si falta un equipo o ya hay ganador.</exception>
    /// <exception cref="ArgumentException">Si el ganador no juega este partido.</exception>
    public void RegistrarGanador(int ganadorId, DateTime fecha)
    {
        if (!ListoParaJugar)
            throw new InvalidOperationException("El partido no tiene sus dos equipos o ya tiene un ganador.");
        if (ganadorId != EquipoAId && ganadorId != EquipoBId)
            throw new ArgumentException("El ganador debe ser uno de los dos equipos del partido.", nameof(ganadorId));

        GanadorId = ganadorId;
        FechaResultado = fecha;
    }

    /// <summary>Coloca un equipo en el lado A o B de este partido.</summary>
    /// <param name="equipoId">Equipo que llega desde la ronda anterior.</param>
    /// <param name="comoEquipoA">Verdadero para el lado A, falso para el lado B.</param>
    public void ColocarEquipo(int equipoId, bool comoEquipoA)
    {
        if (comoEquipoA)
            EquipoAId = equipoId;
        else
            EquipoBId = equipoId;
    }
}
