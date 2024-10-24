using App.Dtos.Base;
using App.Dtos.Simple;
using App.Dtos.Standards;
using AutoMapper;
using Bussines.Entities;

namespace App.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<TransportDto, Transport>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.NewGuid().ToString()))
            .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
            .ReverseMap();



            CreateMap<Flight, FlightDto>()
                .ForMember(dest => dest.Transports, opt => opt.MapFrom(src => src.Transports
                    .Select(t => new SimpleTransportDto
                    {
                        FlightCarrier = t.FlightCarrier,
                        FlightNumber = t.FlightNumber
                    }).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Transports, opt => opt.MapFrom(src => src.Transports
                    .Select(dto => new Transport
                    {
                        Id = Guid.NewGuid().ToString(),
                        FlightCarrier = dto.FlightCarrier,
                        FlightNumber = dto.FlightNumber
                    }).ToList()));

            CreateMap<Transport, BaseTransportDto>()
            .ReverseMap();

            CreateMap<Flight, BaseFlightDto>()
                .ForMember(dest => dest.Transports, opt => opt.MapFrom(src => src.Transports))
                .ReverseMap()
                .ForMember(dest => dest.Transports, opt => opt.MapFrom(src => src.Transports));

            CreateMap<Journey, JourneyDto>()
                .ForMember(dest => dest.Flights, opt => opt.MapFrom(src => src.Flights))
                .ReverseMap()
                .ForMember(dest => dest.Flights, opt => opt.MapFrom(src => src.Flights));


            CreateMap<BaseFlightDto,SimpleFlightDto>().ReverseMap();
            CreateMap<SimpleFlightDto, FlightDto>().ReverseMap();

            CreateMap<BaseJourneyDto, SimpleJourneyDto>().ReverseMap();
            CreateMap<SimpleJourneyDto, JourneyDto>().ReverseMap();

            CreateMap<SimpleTransportDto, BaseTransportDto>().ReverseMap();
            CreateMap<TransportDto, BaseTransportDto>().ReverseMap();
            CreateMap<TransportDto, SimpleTransportDto>().ReverseMap();
            
        }
    }
}
