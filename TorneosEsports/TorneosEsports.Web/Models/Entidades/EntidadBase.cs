namespace TorneosEsports.Web.Models.Entidades;

/// <summary>
/// Clase base abstracta de todas las entidades del proyecto: aporta la llave primaria
/// y la fecha de creación del registro.
/// </summary>
/// <remarks>
/// Es abstracta porque no tiene sentido crear una "entidad" suelta;
/// solo existen sus derivadas (Evento, Torneo, Equipo...). Así no se repiten Id y
/// FechaCreacion en cada clase.
/// </remarks>
public abstract class EntidadBase
{
    /// <summary>Llave primaria que genera la base de datos.</summary>
    public int Id { get; set; }

    /// <summary>Fecha y hora (UTC) en que se creó el registro.</summary>
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
