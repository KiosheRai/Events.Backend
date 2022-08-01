using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Domain;
using System;

namespace Events.Application.Events.Queries.GetEventDetails
{
    public class EventDetailsVm : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventDetailsVm>()
                .ForMember(eventVm => eventVm.Id,
                opt => opt.MapFrom(eve => eve.Id))
                .ForMember(eventVm => eventVm.UserId,
                opt => opt.MapFrom(eve => eve.UserId))
                .ForMember(eventVm => eventVm.Title,
                opt => opt.MapFrom(eve => eve.Title))
                .ForMember(eventVm => eventVm.Details,
                opt => opt.MapFrom(eve => eve.Details))
                .ForMember(eventVm => eventVm.Address,
                opt => opt.MapFrom(eve => eve.Address))
                .ForMember(eventVm => eventVm.EventDate,
                opt => opt.MapFrom(eve => eve.EventDate))
                .ForMember(eventVm => eventVm.CreationDate,
                opt => opt.MapFrom(eve => eve.CreationDate))
                .ForMember(eventVm => eventVm.EditDate,
                opt => opt.MapFrom(eve => eve.EditDate));
        }
    }
}
