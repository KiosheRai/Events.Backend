using FluentValidation;
using System;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(createNoteCommand =>
                 createNoteCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.Address).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.EventDate).NotNull();
            RuleFor(createNoteCommand =>
                createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand =>
                createNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
