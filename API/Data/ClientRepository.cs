using System;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ClientRepository(AppDbContext context, IMapper mapper) : IClientRepository
{
    public void AddClient(Client client)
    {
        context.Clients.Add(client);
    }

    public async Task<PagedList<ClientDto>> GetClientsAsync(ClientParams clientParams)
    {
        var query = context.Clients.AsQueryable();

        return await PagedList<ClientDto>.CreateAsync(query.ProjectTo<ClientDto>(mapper.ConfigurationProvider), clientParams.PageNumber, clientParams.PageSize);
    }

    public async Task<PagedList<ClientDto>> GetClientsStoreProcedureAsync(ClientParams clientParams)
    {
    try
    {
        // Configurar parámetros
        var parameters = new[]
        {
            new SqlParameter("@PageNumber", clientParams.PageNumber),
            new SqlParameter("@PageSize", clientParams.PageSize),
            new SqlParameter("@Country", (object)clientParams.Country ?? DBNull.Value)
        };

        // Ejecutar el procedimiento almacenado para los datos paginados
        var clients = await context.Set<Client>()
            .FromSqlRaw("EXEC sp_ObtenerClientes @PageNumber, @PageSize, @Country", parameters)
            .ToListAsync();

        
        // Mapear a ClientDto
        var clientDtos = mapper.Map<List<ClientDto>>(clients);

        // Crear la lista paginada
        return new PagedList<ClientDto>(clientDtos, clients.Count, clientParams.PageNumber, clientParams.PageSize);
    }
    catch (Exception ex)
    {
        throw new Exception("Error al obtener los clientes", ex);
    }
 }

    public async Task<bool> SaveChanges()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
