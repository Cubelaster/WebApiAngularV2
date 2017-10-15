using BL.Helpers.HelperContracts;
using DAL;
using DAL.Models.IdentityClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Helpers
{
    public class DbInitializer : IDbInitializer
    {
        private readonly HeroContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(HeroContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize(IConfigurationRoot Configuration)
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            List<IdentityRole> roleList = new List<IdentityRole>()
            {
                new IdentityRole("SuperAdmin"),
                new IdentityRole("Administrator"),
                new IdentityRole("StaffMember"),
                new IdentityRole("GuestUser")
            };

            foreach (var role in roleList)
            {
                //If the role already exists, abort
                if (_context.Roles.Any(r => r.Name == role.Name))
                {
                    continue;
                };

                //Create the Role
                await _roleManager.CreateAsync(role);
            }

            //Create the default Admin account and apply the Administrator role
            var defaultUsers = Configuration.GetSection("DefaultUsers").GetChildren();
            foreach(var user in defaultUsers)
            {
                var appUser = new ApplicationUser { UserName = user.GetValue<string>("Username"),
                    Email = user.GetValue<string>("Email"), EmailConfirmed = true,
                    DateRegistered = DateTime.UtcNow,
                    Status = DAL.Contracts.Enumerations.DatabaseEntityStatusEnum.Active };
                await _userManager.CreateAsync(appUser, user.GetValue<string>("Password"));
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(appUser.UserName), "SuperAdmin");
            }
        }
    }
}
