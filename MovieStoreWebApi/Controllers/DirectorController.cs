using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Applications.DirectorOperations.GetDirectors;
using MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class DirectorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public DirectorController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetDirectors()
    {
        GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetDirectorById(int id)
    {
        GetDirectorDetailById query = new GetDirectorDetailById(_context);
        query.DirectorId = id;
        GetDirectorDetailByIdValidator validator = new GetDirectorDetailByIdValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
    {
        CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
        command.Model = newDirector;
        CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel updateDirector)
    {
        UpdateDirectorCommand command = new UpdateDirectorCommand(_context, id);
        command.Id = id;
        command.Model = updateDirector;
        UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirector(int id)
    {
        DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
        command.Id = id;
        DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}