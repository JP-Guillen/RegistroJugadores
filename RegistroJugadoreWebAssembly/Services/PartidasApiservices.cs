﻿using System.Net.Http.Json;
using RegistroJugadoreWebAssembly.Models.ApiDtos;
using RegistroJugadoresWebAssembly.Shared;

namespace RegistroJugadoreWebAssembly.Services;

public interface IPartidasApiservices
{
    Task<Resource<List<PartidaResponse>>> GetPartidasAsync();
    Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidaResponse>> PostPartida(int jugador1, int? jugador2);
    Task<Resource<bool>> UnirsePartidaViaPutAsync(int partidaId, int jugador2Id);
}

public class PartidasApiService(HttpClient httpClient) : IPartidasApiservices
{
    public async Task<Resource<List<PartidaResponse>>> GetPartidasAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<PartidaResponse>>("api/Partidas");
            return new Resource<List<PartidaResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<PartidaResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<PartidaResponse>($"api/Partidas/{partidaId}");
            return new Resource<PartidaResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<PartidaResponse>.Error(ex.Message);
        }
    }

    public async Task<Resource<PartidaResponse>> PostPartida(int jugador1, int? jugador2)
    {
        var request = new PartidaRequest(jugador1, jugador2);
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Partidas", request);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<PartidaResponse>();
            return new Resource<PartidaResponse>.Success(created!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<PartidaResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<PartidaResponse>.Error("Respuesta inválida del servidor.");
        }
    }

    public async Task<Resource<bool>> UnirsePartidaViaPutAsync(int partidaId, int jugador2Id)
    {
        try
        {
           
            var get = await GetPartidaAsync(partidaId);
            if (get is not Resource<PartidaResponse>.Success okGet)
                return new Resource<bool>.Error("No se pudo obtener la partida.");

            var p = okGet.Data;
            if (p.Jugador2Id != null)
                return new Resource<bool>.Error("Ya existe un Jugador O en esta partida.");


            var request = new PartidaRequest(p.Jugador1Id, jugador2Id);
            var resp = await httpClient.PutAsJsonAsync($"api/Partidas/{partidaId}", request);
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
