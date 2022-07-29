using FluentValidation;
using System;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(CreateEventCommand =>
                CreateEventCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(CreateEventCommand =>
                CreateEventCommand.Address).NotEmpty().MaximumLength(50);
            RuleFor(CreateEventCommand =>
                CreateEventCommand.EventDate).NotNull();
            RuleFor(CreateEventCommand =>
                CreateEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
