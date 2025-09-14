using System;
using API.Entities;

namespace API.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsAsync();

    Task<IEnumerable<Client>> GetClientsSPAsync();
    void AddClient(Client client);

    Task<bool> SaveChanges();
}
