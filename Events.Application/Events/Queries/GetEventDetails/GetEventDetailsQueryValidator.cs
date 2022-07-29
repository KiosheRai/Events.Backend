using FluentValidation;
using System;

namespace Events.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
    {
        public GetEventDetailsQueryValidator() { 
            RuleFor(Events => Events.Id).NotEqual(Guid.Empty);
        }
    }
}
