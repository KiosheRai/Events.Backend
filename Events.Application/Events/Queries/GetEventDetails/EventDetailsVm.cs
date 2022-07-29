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
                .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.UserId,
                opt => opt.MapFrom(note => note.UserId))
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Address,
                opt => opt.MapFrom(note => note.Address))
                .ForMember(noteVm => noteVm.EventDate,
                opt => opt.MapFrom(note => note.EventDate))
                .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
