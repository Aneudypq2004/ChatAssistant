namespace P3_Proyecto.ViewModels
{
    public class MessageViewModel
    {

        public DateTime? FechaHora { get; set; }
        public string? Usuario { get; set; }
        public string? Mensaje { get; set; }
        public string? Hora
        {
            get
            {
                if (FechaHora is not null)
                {
                    return FechaHora.Value.ToString("HH:mm");

                }
                return null;
            }
        }
    }
}
