using App.Dtos.Base;
using Bussines.Interfaces;

namespace App.Dtos.Standards;

public class TransportDto : BaseTransportDto, IGenericDto
{
    public string Id { get; set; }
    public string? FlightId { get; set; }
}
