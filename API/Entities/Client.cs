using System;

namespace API.Entities;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Run { get; set; }
    public required string Country { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }


}
