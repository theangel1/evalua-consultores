using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController(IClientRepository clientRepository, IMapper mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            var clients = await clientRepository.GetClientsAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(ClientDto clientDto)
        {
            var client = new Client
            {
                Name = clientDto.Name,
                Run = clientDto.Run,
                Country = clientDto.Country,
                Email = "consultores@evalua.cl",
                Phone = clientDto.Phone
            };

            clientRepository.AddClient(client);


            if (await clientRepository.SaveChanges())
                return Ok(mapper.Map<ClientDto>(client));

            return BadRequest("Failed to save client");


        }
    }
}
