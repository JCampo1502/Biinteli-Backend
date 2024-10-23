using App.Dtos.Simple;
namespace App.Dtos.Base;

public class BaseFlightDto:SimpleFlightDto
{

    
    public ICollection<BaseTransportDto> Transports { get; set; } = [];
}
