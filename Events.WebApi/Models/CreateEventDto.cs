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
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details))
                .ForMember(noteCommand => noteCommand.Address,
                    opt => opt.MapFrom(noteDto => noteDto.Address))
                .ForMember(noteCommand => noteCommand.EventDate,
                    opt => opt.MapFrom(noteDto => noteDto.EventDate));
        }
    }
}
