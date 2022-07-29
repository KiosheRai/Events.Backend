using FluentValidation;
using System;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(UpdateEventCommand =>
                 UpdateEventCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(UpdateEventCommand =>
                UpdateEventCommand.Address).NotEmpty().MaximumLength(50);
            RuleFor(UpdateEventCommand =>
                UpdateEventCommand.EventDate).NotNull();
            RuleFor(UpdateEventCommand =>
                UpdateEventCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(UpdateEventCommand =>
                UpdateEventCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
