using System;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IClientRepository
{
    Task<PagedList<ClientDto>> GetClientsAsync(ClientParams clientParams);

    Task<PagedList<ClientDto>> GetClientsStoreProcedureAsync(ClientParams clientParams);
    void AddClient(Client client);

    Task<bool> SaveChanges();
}
