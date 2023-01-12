using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Controllers.Queries.GetMovies;
using MovieStoreWebApi.DbOperations;

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
}
