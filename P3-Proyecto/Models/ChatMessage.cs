namespace P3_Proyecto.Models;

public partial class ChatMessage
{
    public int Id { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Usuario { get; set; }

    public string? Mensaje { get; set; }
}
