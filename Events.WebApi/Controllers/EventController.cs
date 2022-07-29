using AutoMapper;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Events.Application.Events.Queries.GetEventList;
using Events.Application.Events.Queries.GetEventDetails;
using Events.Application.Events.Commands.CreateEvent;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Application.Events.Commands.DeleteEvent;
using Events.WebApi.Models;
using Microsoft.AspNetCore.Http;

namespace Events.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventDetailsVm>> Get(Guid id)
        {
            var query = new GetEventDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CreateEventDto createNoteDto)
        {
            var command = _mapper.Map<CreateEventCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateEventDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateEventCommand>(updateNoteDto);
            command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var commnad = new DeleteEventCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(commnad);
            return NoContent();
        }
    }
}
