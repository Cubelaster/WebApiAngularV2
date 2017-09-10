using DAL.Contracts.Abstracts;

namespace DAL.Models
{
    public class Hero : DatabaseEntity
    {
        public string Name { get; set; }
    }
}
