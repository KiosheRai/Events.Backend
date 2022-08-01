using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Application.Events.Commands.UpdateEvent;
using System;

namespace Events.WebApi.Models
{
    public class UpdateEventDto : IMapWith<UpdateEventCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEventDto, UpdateEventCommand>()
                .ForMember(eventCommand => eventCommand.Id,
                    opt => opt.MapFrom(eveDto => eveDto.Id))
                .ForMember(eventCommand => eventCommand.Title,
                    opt => opt.MapFrom(eveDto => eveDto.Title))
                .ForMember(eventCommand => eventCommand.Details,
                    opt => opt.MapFrom(eveDto => eveDto.Details))
                .ForMember(eventCommand => eventCommand.Address,
                    opt => opt.MapFrom(eveDto => eveDto.Address))
                .ForMember(eventCommand => eventCommand.EventDate,
                    opt => opt.MapFrom(eveDto => eveDto.EventDate));
        }
    }
}
