using System.ComponentModel.DataAnnotations;

namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Catálogo 2: un torneo que se juega dentro de un evento, con su juego, formato y cupo de equipos.
/// </summary>
/// <remarks>
/// Las reglas del ciclo de vida (cuándo acepta inscripciones, cuándo
/// se puede cerrar, iniciar o finalizar) viven aquí, en el modelo, y no en el controlador:
/// así cualquier parte del sistema que use un torneo respeta las mismas reglas.
/// </remarks>
public class Torneo : EntidadBase
{
    /// <summary>Mínimo de equipos con la inscripción pagada para poder generar las llaves.</summary>
    public const int MinimoEquiposParaLlaves = 2;

    /// <summary>Llave foránea del evento al que pertenece.</summary>
    [Display(Name = "Evento")]
    public int EventoId { get; set; }

    /// <summary>Evento al que pertenece (navegación).</summary>
    public Evento? Evento { get; set; }

    /// <summary>Juego del torneo, por ejemplo «Valorant».</summary>
    [Required, StringLength(80)]
    public string Juego { get; set; } = string.Empty;

    /// <summary>Formato del torneo, por ejemplo «Eliminación directa 5v5».</summary>
    [Required, StringLength(80)]
    public string Formato { get; set; } = "Eliminación directa 5v5";

    /// <summary>Máximo de equipos que se pueden inscribir.</summary>
    [Display(Name = "Cupo de equipos")]
    [Range(2, 64)]
    public int CupoEquipos { get; set; }

    /// <summary>Precio que paga el capitán por todo su equipo, en colones.</summary>
    [Display(Name = "Precio de inscripción")]
    public decimal PrecioInscripcion { get; set; }

    /// <summary>Fecha y hora en que se cierran las inscripciones.</summary>
    [Display(Name = "Cierre de inscripciones")]
    public DateTime CierreInscripciones { get; set; }

    /// <summary>Estado actual del torneo.</summary>
    public EstadoTorneo Estado { get; set; } = EstadoTorneo.Abierto;

    /// <summary>Equipos inscritos (los registra el módulo de inscripción).</summary>
    public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    /// <summary>Partidos de las llaves; existen solo después de cerrar inscripciones.</summary>
    public ICollection<Partido> Partidos { get; set; } = new List<Partido>();

    /// <summary>Indica si el torneo todavía acepta inscripciones.</summary>
    /// <param name="ahora">Fecha y hora actual (se recibe por parámetro para poder probarlo).</param>
    /// <returns>Verdadero si está abierto y no ha pasado la fecha de cierre.</returns>
    public bool AceptaInscripciones(DateTime ahora) =>
        Estado == EstadoTorneo.Abierto && ahora < CierreInscripciones;

    /// <summary>Calcula cuántos equipos más se pueden inscribir.</summary>
    /// <param name="equiposInscritos">Equipos que ya están inscritos.</param>
    /// <returns>Cupos libres; nunca negativo.</returns>
    public int CuposDisponibles(int equiposInscritos) => Math.Max(0, CupoEquipos - equiposInscritos);

    /// <summary>Solo un torneo con inscripciones abiertas se puede editar.</summary>
    public bool PuedeEditarse => Estado == EstadoTorneo.Abierto;

    /// <summary>Pasa el torneo de Abierto a Cerrado.</summary>
    /// <exception cref="InvalidOperationException">Si el torneo no está abierto.</exception>
    public void CerrarInscripciones()
    {
        if (Estado != EstadoTorneo.Abierto)
            throw new InvalidOperationException("Solo se pueden cerrar las inscripciones de un torneo abierto.");
        Estado = EstadoTorneo.Cerrado;
    }

    /// <summary>Pasa el torneo de Cerrado a EnJuego, después de generar las llaves.</summary>
    /// <exception cref="InvalidOperationException">Si las inscripciones no están cerradas.</exception>
    public void IniciarJuego()
    {
        if (Estado != EstadoTorneo.Cerrado)
            throw new InvalidOperationException("El torneo debe tener las inscripciones cerradas para iniciar.");
        Estado = EstadoTorneo.EnJuego;
    }

    /// <summary>Pasa el torneo de EnJuego a Finalizado, cuando la final tiene ganador.</summary>
    /// <exception cref="InvalidOperationException">Si el torneo no está en juego.</exception>
    public void Finalizar()
    {
        if (Estado != EstadoTorneo.EnJuego)
            throw new InvalidOperationException("Solo se puede finalizar un torneo que está en juego.");
        Estado = EstadoTorneo.Finalizado;
    }
}
