namespace GameStore.Models
{
    public class Juego_Plataforma
    {
        public int JuegoId { get; set; }
        public Juego Juego { get; set; }
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
    }
}
