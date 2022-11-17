using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Genero requerido")]
        public string nombreGenero { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descrpicion requerida")]
        public string descripcion { get; set; }

        //Relaciones con juegos
        public List<Juego> Juegos { get; set; }
    }
}
