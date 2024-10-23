namespace Bussines.Entities;

public class Journey:BaseEntity
{
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public required float Price { get; set; }

    public IEnumerable<Flight> Flights { get; set; } = [];
}
