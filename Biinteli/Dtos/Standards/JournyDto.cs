using App.Dtos.Base;
using Bussines.Interfaces;

namespace App.Dtos.Standards;

public class JourneyDto:BaseJourneyDto, IGenericDto
{
    public string Id { get; set; }
}
