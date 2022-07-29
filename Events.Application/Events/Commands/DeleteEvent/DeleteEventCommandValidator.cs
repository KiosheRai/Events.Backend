using FluentValidation;
using System;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
