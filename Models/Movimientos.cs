using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroJugadores.Models;

    public class Movimientos
    {
        [Key]
        public int MovimientoId { get; set; }
        public int PartidaId { get; set; }
        public int JugadorId { get; set; }
        [Range(0, 2)]
        public int PosicionFila { get; set; }
        [Range(0,2)]
        public int PosicionColumna {  get; set; }
        public DateTime FechaMoviemiento { get; set; } = DateTime.UtcNow;


        //Propiedades de navegacion
        [ForeignKey(nameof(PartidaId))]
        public virtual Partidas Partidas { get; set; }

        [ForeignKey(nameof(JugadorId))]
        public virtual Jugadores Jugadores { get; set; }
    }

