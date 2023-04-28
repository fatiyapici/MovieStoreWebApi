using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<MovieDirector> Directors { get; set; }
        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<MovieActor> Actors { get; set; }
    }

    public class MovieGenre
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }

    public class MovieActor
    {
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }

    public class MovieDirector
    {
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}