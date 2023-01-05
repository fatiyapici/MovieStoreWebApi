using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}