using DAL.Contracts.Enumerations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace DAL.Models.IdentityClasses
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public DatabaseEntityStatusEnum Status { get; set; }
    }
}
