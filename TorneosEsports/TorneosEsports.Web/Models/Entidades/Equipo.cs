using System.ComponentModel.DataAnnotations;
using TorneosEsports.Web.Data;

namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Equipo inscrito en un torneo. Lo crea el capitán, que paga por todo el equipo.
/// </summary>
/// <remarks>
/// Las llaves se arman solo con los equipos que tienen <see cref="Pagado"/> en verdadero.
/// Nota para Stefanny: al aprobarse el pago de la inscripción hay que marcar Pagado = true.
/// </remarks>
public class Equipo : EntidadBase
{
    /// <summary>Cantidad de integrantes que exige la regla del proyecto.</summary>
    public const int IntegrantesRequeridos = 5;

    /// <summary>Llave foránea del torneo.</summary>
    public int TorneoId { get; set; }

    /// <summary>Torneo en el que está inscrito.</summary>
    public Torneo? Torneo { get; set; }

    /// <summary>Nombre del equipo; único dentro del torneo.</summary>
    [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
    [StringLength(60)]
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Id del usuario capitán (Identity).</summary>
    [Required]
    public string CapitanId { get; set; } = string.Empty;

    /// <summary>Usuario capitán (navegación).</summary>
    public ApplicationUser? Capitan { get; set; }

    /// <summary>Verdadero cuando el pago de la inscripción fue aprobado.</summary>
    public bool Pagado { get; set; }

    /// <summary>Los cinco integrantes registrados por el capitán.</summary>
    public ICollection<IntegranteEquipo> Integrantes { get; set; } = new List<IntegranteEquipo>();
}
