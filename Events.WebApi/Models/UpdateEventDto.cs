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
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
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
