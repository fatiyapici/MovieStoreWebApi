using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public virtual ICollection<MovieActor> Movies { get; set; }
    }

    public class MovieActor
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}