using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Application.Events.Commands.CreateEvent;
using System;
using System.ComponentModel.DataAnnotations;

namespace Events.WebApi.Models
{
    public class CreateEventDto : IMapWith<CreateEventCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime EventDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(eventCommand => eventCommand.Title,
                    opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Details,
                    opt => opt.MapFrom(eventDto => eventDto.Details))
                .ForMember(eventCommand => eventCommand.Address,
                    opt => opt.MapFrom(eventDto => eventDto.Address))
                .ForMember(eventCommand => eventCommand.EventDate,
                    opt => opt.MapFrom(eventDto => eventDto.EventDate));
        }
    }
}
