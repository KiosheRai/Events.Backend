using FluentValidation;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryValidator : AbstractValidator<GetEventListQuery>
    {
        public GetEventListQueryValidator() { }
    }
}
