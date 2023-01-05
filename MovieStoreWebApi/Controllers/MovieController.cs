// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using MovieStoreWebApi.DbOperations;

// namespace MovieStoreWebApi.Controllers;

// [Authorize]
// [ApiController]
// [Route("[controller]s")]
// public class MovieController : ControllerBase
// {
//     private readonly IMapper _mapper;
//     private readonly IMovieStoreDbContext _context;

//     public MovieController(IMapper mapper, IMovieStoreDbContext context)
//     {
//         _mapper = mapper;
//         _context = context;
//     }

//     [HttpGet]
//     public IActionResult GetMovies()
//     {
//         GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
//         var result = query.Handle();

//         return Ok();
//     }

//     [HttpGet("{id}")]
//     public IActionResult GetById(int id)
//     {

//     }
// }
