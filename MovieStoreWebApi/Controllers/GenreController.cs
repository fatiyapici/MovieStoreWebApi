using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.GenreOperations.Queries.GetGenres;
using static MovieStoreWebApi.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

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
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
    {
        var genre = _mapper.Map<Genre>(newGenre);
        CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
        command.Model = genre;
        command.Handle();
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreViewModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context, id);
        command.Id = id;
        command.Model = updateGenre;
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.Id = id;
        command.Handle();
        return Ok();
    }
}