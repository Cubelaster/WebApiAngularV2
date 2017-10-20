using AutoMapper;
using BL.Helpers.HelperContracts;
using DAL;
using DAL.Models.IdentityClasses;
using DAL.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BL.Helpers
{
    public class DbInitializer : IDbInitializer
    {
        private readonly HeroContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private List<Claim> applicationClaims;

        public DbInitializer(HeroContext context, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async void Initialize(IConfigurationRoot Configuration)
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            applicationClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "LoggedInClaim" )
            };

            List<Claims> claims = _mapper.Map<List<Claims>>(applicationClaims);
            _context.Claims.AddRange(claims);
            await _context.SaveChangesAsync();

            List<IdentityRole> roleList = new List<IdentityRole>()
            {
                new IdentityRole("SuperAdmin"),
                new IdentityRole("Administrator"),
                new IdentityRole("StaffMember"),
                new IdentityRole("GuestUser")
            };

            foreach (var role in roleList)
            {
                await SeederAsync(role);
            }

            if (!_context.Users.Any())
            {
                var defaultUsers = Configuration.GetSection("DefaultUsers").GetChildren();
                foreach (var user in defaultUsers)
                {
                    var appUser = new ApplicationUser
                    {
                        UserName = user.GetValue<string>("Username"),
                        Email = user.GetValue<string>("Email"),
                        EmailConfirmed = true,
                        DateRegistered = DateTime.UtcNow,
                        Status = DAL.Contracts.Enumerations.DatabaseEntityStatusEnum.Active
                    };
                    await _userManager.CreateAsync(appUser, user.GetValue<string>("Password"));
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(appUser.UserName), "SuperAdmin");
                }
            }
        }

        public async Task SeederAsync(IdentityRole role)
        {
            switch(role.Name)
            {
                case "SuperAdmin":
                    await SeedSuperAdminAsync(role);
                    break;
                default:
                    break;
            }
        }

        public async Task SeedSuperAdminAsync(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            foreach(var claim in applicationClaims)
            {
                await _roleManager.AddClaimAsync(role, claim);
            }
        }
    }
}
