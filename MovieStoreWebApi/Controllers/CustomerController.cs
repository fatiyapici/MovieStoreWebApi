using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomers;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public CustomerController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        GetCustomerDetailById query = new GetCustomerDetailById(_context, _mapper);
        query.CustomerId = id;
        var result = query.Handle();

        return Ok(result);
    }

    // [HttpPost]
    // public IActionResult AddActor([FromBody] CreateActorViewModel newActor)
    // {
    //     CreateActorCommand command = new CreateActorCommand(_context, _mapper);
    //     command.Model = newActor;
    //     command.Handle();
    //     return Ok();
    // }

    // [HttpPut("{id}")]
    // public IActionResult UpdateActor(int id, [FromBody] UpdateActorViewModel updateActor)
    // {
    //     UpdateActorCommand command = new UpdateActorCommand(_context, id);
    //     command.Id = id;
    //     command.Model = updateActor;
    //     command.Handle();
    //     return Ok();
    // }

    // [HttpDelete("{id}")]
    // public IActionResult DeleteActor(int id)
    // {
    //     DeleteActorCommand command = new DeleteActorCommand(_context);
    //     command.Id = id;
    //     command.Handle();
    //     return Ok();
    // }
}