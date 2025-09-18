using Microsoft.EntityFrameworkCore;
using RegistroJugadores.DAL;
using RegistroJugadores.Models;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace RegistroJugadores.Services
{
    public class PartidasService(IDbContextFactory<Contexto> DbFactory)
    {

       //Metodo Guardar
        public async Task<bool> Guardar(Partidas partida)
        {
            if (!await Existe(partida.PartidaId))
            {
                return await Insertar(partida);
            }
            else
            {
                return await Modificar(partida);
            }
        }

        // MEtodo existe
        private async Task<bool>Existe(int partidaid)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.partidas
                .AnyAsync(p=> p.PartidaId == partidaid);
        }

        //Metodo Insertar
        private async Task<bool> Insertar(Partidas partida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.partidas.Add(partida);
            return await contexto.SaveChangesAsync() > 0;

        }

        //Metodo modificar
        private async Task<bool> Modificar(Partidas partida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(partida);
            return await contexto
                .SaveChangesAsync() > 0;
        }

        //Metodo Buscar
        public async Task<Partidas?> Buscar(int partidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.partidas.FirstOrDefaultAsync(p=>p.PartidaId == partidaId);
        }

        //Metodo ELiminar

        public async Task<bool> Eliminar(int partidaId)
        {
            await using  var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.partidas
                .AsNoTracking()
                .Where(p => p.PartidaId == partidaId)
                .ExecuteDeleteAsync() > 0;
        }

        //Metodo Listar
        public async Task<List<Partidas>> Listar(Expression<Func<Partidas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.partidas
                .Include(p => p.Jugador1)
                .Include(p => p.Jugador2)
                .Include(p => p.Ganador)
                .Include(p => p.TurnoJugador)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }


    }
}
