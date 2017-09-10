using DAL.Contracts.Abstracts;

namespace DAL.Models
{
    public class Product : DatabaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
