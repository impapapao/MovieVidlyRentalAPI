using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieVidlyRental.Data;
using MovieVidlyRental.Models;
using MovieVidlyRental.Models.ViewModel;
using MovieVidlyRental.Service;

namespace MovieVidlyRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        
        public MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get-all-movie")]
        public IActionResult GetAllMovie() 
        {
            var allmovie = _movieService.GetAllMovie();
            return Ok(allmovie);
        }

        [HttpGet("get-movie-by-id/{id}")]
        public IActionResult GetMovie(int id)
        {
            var Movie = _movieService.GetMovieById(id);
            return Ok(Movie);
        }

        [HttpPost("add-movie")]
        public IActionResult AddMovie([FromBody]MovieVM movie)
        {
            _movieService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("update-movie-by-id/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody]MovieVM movie)
        {
            var updateMovie = _movieService.UpdateMovieById(id, movie);
            return Ok(updateMovie);
        }

        [HttpDelete("delete-movie-by-id/{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            _movieService.DeleteMovieById(id);
            return Ok();
        }
       
    }
}
