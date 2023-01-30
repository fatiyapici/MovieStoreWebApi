using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.ActorOperations.Queries.GetActorDetail;
using MovieStoreWebApi.ActorOperations.Queries.GetActors;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteActor;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.DbOperations;
using static MovieStoreWebApi.ActorOperations.Commands.CreateActor.CreateActorCommand;

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
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddActor([FromBody] CreateActorViewModel newActor)
    {
        CreateActorCommand command = new CreateActorCommand(_context, _mapper);
        command.Model = newActor;
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor(int id, [FromBody] UpdateActorViewModel updateActor)
    {
        UpdateActorCommand command = new UpdateActorCommand(_context, id);
        command.Id = id;
        command.Model = updateActor;
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
        DeleteActorCommand command = new DeleteActorCommand(_context);
        command.Id = id;
        command.Handle();
        return Ok();
    }
}