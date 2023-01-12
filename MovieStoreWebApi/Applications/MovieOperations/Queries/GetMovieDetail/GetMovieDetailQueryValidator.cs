using FluentValidation;

namespace MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
        }
    }
}