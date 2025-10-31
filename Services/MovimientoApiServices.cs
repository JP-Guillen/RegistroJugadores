using RegistroJugadores.Models.ApiDtos;
using RegistroJugadoresResource;
using System.Net.Http.Json;

namespace RegistroJugadoreApi.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientosResponse>>> GetMovimientosAsync(int partidaId);
    Task<Resource<bool>> PostMovimientoAsync(MovimientosRequest request);
}

public class MovimientosApiService(HttpClient httpClient) : IMovimientosApiService
{
    public async Task<Resource<List<MovimientosResponse>>> GetMovimientosAsync(int partidaId)
    {
        try
        {
            var data = await httpClient.GetFromJsonAsync<List<MovimientosResponse>>($"api/Movimientos/{partidaId}");
            return new Resource<List<MovimientosResponse>>.Success(data ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<MovimientosResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<bool>> PostMovimientoAsync(MovimientosRequest request)
    {
        try
        {
            var resp = await httpClient.PostAsJsonAsync("api/Movimientos", request);
            resp.EnsureSuccessStatusCode();
            return new Resource<bool>.Success(true);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<bool>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<bool>.Error("Respuesta inválida del servidor.");
        }
    }
}

