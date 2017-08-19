using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
