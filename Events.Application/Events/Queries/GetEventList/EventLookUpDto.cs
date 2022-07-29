using AutoMapper;
using Events.Domain;
using System;

namespace Events.Application.Events.Queries.GetEventList
{
    public class EventLookUpDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookUpDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDto => noteDto.UserId,
                        opt => opt.MapFrom(note => note.UserId))
                .ForMember(noteDto => noteDto.EventDate,
                        opt => opt.MapFrom(note => note.EventDate));
        }
    }
}
