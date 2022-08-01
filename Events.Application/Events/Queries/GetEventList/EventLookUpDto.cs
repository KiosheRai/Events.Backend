using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Domain;
using System;

namespace Events.Application.Events.Queries.GetEventList
{
    public class EventLookUpDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookUpDto>()
                .ForMember(eventDto => eventDto.Id,
                    opt => opt.MapFrom(eve => eve.Id))
                .ForMember(eventDto => eventDto.Title,
                    opt => opt.MapFrom(eve => eve.Title))
                .ForMember(eventDto => eventDto.UserId,
                        opt => opt.MapFrom(eve => eve.UserId))
                .ForMember(eventDto => eventDto.EventDate,
                        opt => opt.MapFrom(eve => eve.EventDate));
        }
    }
}
