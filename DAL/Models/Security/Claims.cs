using DAL.Contracts.Enumerations;
using System;

namespace DAL.Models.Security
{
    public class Claims
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DatabaseEntityStatusEnum Status { get; set; }
    }
}
