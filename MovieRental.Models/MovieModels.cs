using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public string MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string FilmRating { get; set; }
        public string Language { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        private List<MovieGenre> genres = new List<MovieGenre>();
        public virtual List<MovieGenre> Genres
        {
            get
            {
                return genres;
            }
            set
            {
                genres = value;
            }
        }
        [Required]
        public int NoInStock { get; set; }
        [Required]
        public double RentalRate { get; set; }
        public string ImdbRating { get; set; }
    }

    public class Genre
    {
        public Genre() { }
        public Genre(string genre)
        {
            Description = genre;
        }
        [Key]
        public string Description { get; set; }
        private List<MovieGenre> movies = new List<MovieGenre>();
        public virtual List<MovieGenre> Movies
        {
            get
            {
                return movies;
            }
        }
    }

    public class MovieGenre
    {
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
