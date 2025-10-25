using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;
using RegistroJugadores.Models;
using System.Linq.Expressions;

namespace RegistroJugadores.Services
{
    public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
    {


        private async Task<bool> ExisteNombre(string nombres)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.AnyAsync(j => j.Nombres.ToLower().Trim().Equals(nombres.ToLower().Trim()));
        }

        public async Task <bool> Guardar(Jugadores jugador) {

            if (await ExisteNombre(jugador.Nombres) && !await Existe(jugador.JugadorId))
            {
                return false;
            }

            if (!await Existe(jugador.JugadorId))
            {
                return await Insertar(jugador);
            }
            else
            {
                return await Modificar(jugador);
            }
        
        }

        private async Task<bool> Existe(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AnyAsync(j => j.JugadorId == jugadorId);

        }
        private async Task<bool> Insertar(Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Jugadores.Add(jugador);
            return await contexto.SaveChangesAsync() > 0;

        }

        private async Task<bool> Modificar(Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(jugador);
            return await contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<Jugadores?> Buscar(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.FirstOrDefaultAsync(j => j.JugadorId == jugadorId);
        }

        public async Task<bool> Eliminar(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AsNoTracking()
                .Where(j => j.JugadorId == jugadorId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Jugadores>> Listar(Expression<Func<Jugadores, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
