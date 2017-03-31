using System.Collections.Generic;
using MovieRental.Models;

namespace MovieRental.Data
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Delete(string id);
        IEnumerable<Movie> FindMoviesByTitle(string title);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(string id);
        void Save();
    }
}