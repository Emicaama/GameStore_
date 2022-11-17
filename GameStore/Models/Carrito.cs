using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace GameStore.Models
{
    public class Carrito
    {
        [Key]
        public int idTienda { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Página Web")]
        public string resumen { get; set; }
        [Display(Name = "Imagen")]
        public string? imagenJuego { get; set; }

        //relaciones
        public List<Juego>? Juegos { get; set; }
    }
}