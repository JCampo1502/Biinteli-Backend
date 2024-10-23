namespace Bussines.Entities;

public class Transport : BaseEntity
{
    public required string FlightCarrier { get; set; }
    public required string FlightNumber { get; set; }

    public string? FlightId { get; set; }
    public Flight? Flight { get; set; }
}
