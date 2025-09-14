using System;

namespace API.DTOs;

public class ClientDto
{
    public required string Name { get; set; }
    public required string Run { get; set; }
    public required string Country { get; set; }
    public required string Phone { get; set; }
}
