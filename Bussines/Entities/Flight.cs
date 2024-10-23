namespace Bussines.Entities;

public class Flight : BaseEntity
{
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public required float Price { get; set; }

    public string? JourneyId { get; set; } 
    public Journey? Journey { get; set; }  

    public IEnumerable<Transport> Transports { get; set; } = []; 
}
