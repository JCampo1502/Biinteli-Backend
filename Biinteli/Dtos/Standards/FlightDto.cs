using App.Dtos.Base;
using Bussines.Interfaces;

namespace App.Dtos.Standards;

public class FlightDto : BaseFlightDto, IGenericDto
{
    public string Id { get; set; }
    public string? JourneyId { get; set; }
}
