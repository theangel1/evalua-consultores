using System;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public void AddClient(Client client)
    {
        context.Clients.Add(client);
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await context.Clients.ToListAsync();
    }

    public Task<IEnumerable<Client>> GetClientsSPAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChanges()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
