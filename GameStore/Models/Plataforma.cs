using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Plataforma
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo requerido")]
        public string plataformaFotoUrl { get; set; }
        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "Plataforma requerida")]
        public string nombrePlataforma { get; set; }


        //relacion con juegos
        public List<Juego_Plataforma> Juegos_Plataformas { get; set; }
    }
}
