using System.ComponentModel.DataAnnotations;

namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Jugador de un equipo, registrado por el capitán.
/// </summary>
/// <remarks>Estructura base para la migración inicial; se puede ampliar desde el módulo de inscripción y carrito.</remarks>
public class IntegranteEquipo : EntidadBase
{
    /// <summary>Llave foránea del equipo.</summary>
    public int EquipoId { get; set; }

    /// <summary>Equipo al que pertenece.</summary>
    public Equipo? Equipo { get; set; }

    /// <summary>Nombre completo del jugador.</summary>
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Nombre de jugador dentro del juego.</summary>
    [Required(ErrorMessage = "El nick es obligatorio.")]
    [StringLength(40)]
    public string Nick { get; set; } = string.Empty;

    /// <summary>Correo del jugador.</summary>
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no es válido.")]
    [StringLength(120)]
    public string Correo { get; set; } = string.Empty;
}
