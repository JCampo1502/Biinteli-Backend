using App.Dtos.Simple;
using Bussines.Entities;

namespace App.Dtos.Base;

public class BaseJourneyDto: SimpleJourneyDto
{
    

    public ICollection<BaseFlightDto> Flights { get; set; } = [];
}
