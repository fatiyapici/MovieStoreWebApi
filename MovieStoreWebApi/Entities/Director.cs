using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public virtual ICollection<MovieDirector> DirectedMovies { get; set; }
    }

    public class MovieDirector
    {
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}