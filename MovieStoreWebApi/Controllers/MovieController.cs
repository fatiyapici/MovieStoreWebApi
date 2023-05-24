using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovies;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using MovieStoreWebApi.Applications.MovieOperations.Commands.UpdateMovie;
using MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class MovieController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public MovieController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        MovieDetailViewModel result;
        GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
        query.MovieId = id;
        GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
    {
        CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
        command.Model = newMovie;
        CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie([FromBody] UpdateMovieViewModel updateMovie, int id)
    {
        UpdateMovieCommand command = new UpdateMovieCommand(_context);
        command.MovieId = id;
        command.Model = updateMovie;
        UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        DeleteMovieCommand command = new DeleteMovieCommand(_context);
        command.Id = id;
        DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
