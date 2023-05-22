using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenres;
using MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById;
using MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre;
using static MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using MovieStoreWebApi.Applications.GenreOperations.Commands.GenreDirector;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class GenreController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public GenreController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        GetGenresQuery query = new GetGenresQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetGenreById(int id)
    {
        GetGenreDetailById query = new GetGenreDetailById(_context);
        query.GenreId = id;
        GetGenreDetailByIdValidator validator = new GetGenreDetailByIdValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
    {
        var genre = _mapper.Map<CreateGenreViewModel>(newGenre);
        CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
        command.Model = genre;
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreViewModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context, id);
        command.Id = id;
        command.Model = updateGenre;
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.Id = id;
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}