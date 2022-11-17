using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class Juego
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Caratula")]
        [Required(ErrorMessage = "Caratula requerida")]
        public string juegoFotoUrl { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Titulo requerido")]
        public string nombreJuego { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descripcion requerida")]
        public string descripcion { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Precio requerido")]
        public double precio { get; set; }

        [Display(Name = "Fecha de publicacion")]
        [Required(ErrorMessage = "Fecha de publicacion requerida")]
        public DateTime fechaPublicacion { get; set; }


        //Relaciones

        public List<Juego_Plataforma> Juegos_Plataformas { get; set; }

        //Genero
        public int GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }

        //Empresa
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

    }
}
