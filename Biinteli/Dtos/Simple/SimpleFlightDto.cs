namespace App.Dtos.Simple;

public class SimpleFlightDto
{
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public required float Price { get; set; }
    
}
