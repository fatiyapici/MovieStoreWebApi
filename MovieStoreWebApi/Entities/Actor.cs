using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}