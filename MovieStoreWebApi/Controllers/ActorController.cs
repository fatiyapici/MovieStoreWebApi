using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Applications.ActorOperations.Queries.GetActors;
using MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail;
using MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Applications.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Applications.ActorOperations.Commands.DeleteActor;
using static MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor.CreateActorCommand;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class ActorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public ActorController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetActors()
    {
        GetActorsQuery query = new GetActorsQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetActorById(int id)
    {
        GetActorDetailById query = new GetActorDetailById(_context, _mapper);
        query.ActorId = id;
        GetActorDetailByIdValidator validator = new GetActorDetailByIdValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddActor([FromBody] CreateActorViewModel newActor)
    {
        CreateActorCommand command = new CreateActorCommand(_context, _mapper);
        command.Model = newActor;
        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor([FromBody] UpdateActorViewModel updateActor,int id)
    {
        UpdateActorCommand command = new UpdateActorCommand(_context);
        command.ActorId = id;
        command.Model = updateActor;
        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
        DeleteActorCommand command = new DeleteActorCommand(_context);
        command.ActorId = id;
        DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}