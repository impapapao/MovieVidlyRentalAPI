using MovieVidlyRental.Data;
using MovieVidlyRental.Models;
using MovieVidlyRental.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MovieVidlyRental.Service
{
    public class MovieService
    {
        public AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovie() => _context.Movie.ToList();

        public Movie GetMovieById(int MovieId) => _context.Movie.FirstOrDefault(m => m.MovieId == MovieId);

        public void AddMovie(MovieVM movie) 
        {
            var _movie = new Movie()
            {
                MovieTitle = movie.MovieTitle,
                Description = movie.Description,
                Genre = movie.Genre
            };
            _context.Movie.Add(_movie);
            _context.SaveChanges();
        }

        public Movie UpdateMovieById(int movieId, MovieVM movie)
        {
            var _movie = _context.Movie.FirstOrDefault(m => m.MovieId == movieId);
            if(_movie != null)
            {
                _movie.MovieTitle = movie.MovieTitle;
                _movie.Description = movie.Description;
                _movie.Genre = movie.Genre;

                _context.SaveChanges();
            }

            return _movie;
        }

        public void DeleteMovieById(int movieId)
        {
            var _movie = _context.Movie.FirstOrDefault(m => m.MovieId == movieId);
            if(_movie != null )
            {
                _context.Movie.Remove(_movie);
                _context.SaveChanges();
            }
        }
    }
}
