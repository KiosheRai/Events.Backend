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

        /// <summary>
        /// Gets the list of events
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /event
        /// </remarks>
        /// <returns>Returns EventListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the event by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /event/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">event id (guid)</param>
        /// <returns>Returns EventDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EventDetailsVm>> Get(Guid id)
        {
            var query = new GetEventDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the event
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /event
        /// {
        ///     title: "event title",
        ///     details: "event details"
        ///     address: "event address"
        ///     eventDate:
        /// }
        /// </remarks>
        /// <param name="createEventDto">CreateEventDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CreateEventDto createEventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(createEventDto);
            command.UserId = UserId;
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }

        /// <summary>
        /// Updates the event
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /event
        /// {
        ///     title: "new event title",
        ///     details: "new event details"
        ///     address: "new event address"
        ///     eventDate:
        /// }
        /// </remarks>
        /// <param name="updateEventDto">UpdateEventDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateEventDto updateEventDto)
        {
            var command = _mapper.Map<UpdateEventCommand>(updateEventDto);
            command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the event by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /event/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the events (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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
