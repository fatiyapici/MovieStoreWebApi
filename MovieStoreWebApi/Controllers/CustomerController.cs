using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Applications.CustomerOperations.Commands.CreateToken;
using MovieStoreWebApi.Applications.CustomerOperations.Commands.UpdateCustomer;
using MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomers;
using MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.Applications.UserOperations.Commands.RefreshToken;
using MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.TokenOperations.Models;
using MovieStoreWebApi.Validations.CustomerOperations.DeleteCustomer;
using static MovieStoreWebApi.Applications.CustomerOperations.Commands.CreateToken.CreateTokenCommand;
using static MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer.UpdateCustomerCommand;
using static MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace MovieStoreWebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;
    readonly IConfiguration _configuration;

    public CustomerController(IMapper mapper, IMovieStoreDbContext context, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
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
        GetCustomerDetailByIdValidator validator = new GetCustomerDetailByIdValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost("newCustomer")]
    public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
        command.Model = newCustomer;
        CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer([FromBody] UpdateCustomerViewModel updateCustomer, int id)
    {
        UpdateCustomerCommand command = new UpdateCustomerCommand(_context, id);
        command.Id = id;
        command.Model = updateCustomer;
        UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id, string email, string password)
    {
        DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
        command.Model.Id = id;
        command.Model.Email = email;
        command.Model.Password = password;
        DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
        command.Model = login;
        var token = command.Handle();
        return token;
    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
        command.RefreshToken = token;
        var resultToken = command.Handle();
        return resultToken;
    }
}