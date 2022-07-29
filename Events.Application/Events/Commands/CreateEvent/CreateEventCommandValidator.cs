using FluentValidation;
using System;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.Address).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.EventDate).NotNull();
            RuleFor(createNoteCommand =>
                createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
