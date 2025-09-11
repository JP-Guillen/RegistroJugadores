using System.ComponentModel.DataAnnotations;

namespace RegistroJugadores.Models
{
    public class Jugadores
    {
        [Key]
        public int Idjugador { get; set; }

        [Required(ErrorMessage = "El campo 'Nombres' es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage= "EL Campo 'Partidas' es obigatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El numero de partidas debe ser un valor valido. ")]
        public int Partidas { get; set; }

    }
}
