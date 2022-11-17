using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo requerido")]
        public string empresaFotoUrl { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido")]
        public string nombreEmpresa { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descripcion requerida")]
        public string descripcion { get; set; }

        //Relacion con Juegos 
        public List<Juego> Juegos { get; set; }
    }
}
