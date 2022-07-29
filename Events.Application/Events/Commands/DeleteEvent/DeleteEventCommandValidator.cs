using FluentValidation;
using System;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(DeleteEventCommand =>
                DeleteEventCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(DeleteEventCommand =>
                DeleteEventCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
