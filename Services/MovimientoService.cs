using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;
using RegistroJugadores.Models;
using System.Linq.Expressions;

namespace RegistroJugadores.Services
{
    public class MovimientosService(IDbContextFactory<Contexto> DbFactory)
    {
        // Método Guardar
        public async Task<bool> Guardar(Movimientos movimiento)
        {
                return await Insertar(movimiento);
        }

        // Método Insertar
        private async Task<bool> Insertar(Movimientos movimiento)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.movimientos.Add(movimiento);
            return await contexto.SaveChangesAsync() > 0;
        }

    }
}
