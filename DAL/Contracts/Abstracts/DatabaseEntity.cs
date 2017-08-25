using DAL.Contracts.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Contracts.Abstracts
{
    public abstract class DatabaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DatabaseEntityStatusEnum Status { get; set; }
    }
}
