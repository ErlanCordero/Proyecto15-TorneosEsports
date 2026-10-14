using System.ComponentModel.DataAnnotations;

namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Catálogo 1: un evento (LAN party o festival de esports) con su sede, fecha y cupo de puestos.
/// </summary>
/// <remarks>
/// Dejo la estructura base para la migración inicial. Nota para Erlan: si el catálogo
/// necesita más campos o validaciones, se agregan aquí con una migración nueva.
/// </remarks>
public class Evento : EntidadBase
{
    /// <summary>Nombre visible del evento.</summary>
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(120)]
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Lugar donde se realiza.</summary>
    [Required(ErrorMessage = "La sede es obligatoria.")]
    [StringLength(120)]
    public string Sede { get; set; } = string.Empty;

    /// <summary>Fecha y hora de inicio del evento.</summary>
    [Display(Name = "Fecha del evento")]
    [DataType(DataType.DateTime)]
    public DateTime Fecha { get; set; }

    /// <summary>Cantidad de puestos (computadoras) disponibles en la LAN.</summary>
    [Display(Name = "Cupo de puestos")]
    [Range(1, 5000, ErrorMessage = "El cupo debe estar entre {1} y {2}.")]
    public int CupoPuestos { get; set; }

    /// <summary>Precio del pase de entrada a la LAN, en colones.</summary>
    [Display(Name = "Precio del pase")]
    [Range(typeof(decimal), "0", "1000000", ErrorMessage = "El precio debe estar entre {1} y {2}.")]
    public decimal PrecioPase { get; set; }

    /// <summary>Ruta o URL pública de la imagen ilustrativa.</summary>
    [Display(Name = "Imagen")]
    [StringLength(300)]
    public string? ImagenUrl { get; set; }

    /// <summary>Descripción para la página de detalle.</summary>
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    /// <summary>Torneos que se juegan en este evento (catálogo 2).</summary>
    public ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();
}
