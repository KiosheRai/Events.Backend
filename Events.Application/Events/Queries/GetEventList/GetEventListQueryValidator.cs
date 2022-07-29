using FluentValidation;
using System;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryValidator : AbstractValidator<GetEventListQuery>
    {
        public GetEventListQueryValidator()
        {
            RuleFor(Event => Event.UserId).NotEqual(Guid.Empty);
        }
    }
}
