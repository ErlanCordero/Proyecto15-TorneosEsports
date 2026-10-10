namespace TorneosEsports.Web.Data
{
    public class BitacoraAccion
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; } = string.Empty;

        public string CorreoUsuario { get; set; } = string.Empty;

        public string Accion { get; set; } = string.Empty;

        public string? Detalle { get; set; }

        public DateTime FechaHora { get; set; }
    }
}