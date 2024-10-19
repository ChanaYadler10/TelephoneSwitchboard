// Repository / Implementations / RepresentativeRepository.cs
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using Repository.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Repository.View_Models;

namespace Repository.Implementations
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RepresentativeRepository> _logger;

        public RepresentativeRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<RepresentativeRepository> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public RepresentativeInfo GetRepresentativeInfo(string representativeId)
        {
            var user = _userManager.FindByIdAsync(representativeId).Result;
            if (user == null)
            {
                return null;
            }

            var roles = _userManager.GetRolesAsync(user).Result;
            var roleClaims = new List<string>();

            foreach (var role in roles)
            {
                var roleClaimsList = _roleManager.GetClaimsAsync(new IdentityRole(role)).Result;
                roleClaims.AddRange(roleClaimsList.Select(c => c.Value));
            }

            return new RepresentativeInfo
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleClaims = roleClaims
            };
        }

        public List<RepresentativeInfo> GetAllRepresentativesWithRoleClaims()
        {
            var users = _userManager.Users.ToList();
            var representatives = new List<RepresentativeInfo>();

            foreach (var user in users)
            {
                var userRoles = _userManager.GetRolesAsync(user).Result;
                var roles = new List<string>();

                foreach (var userRole in userRoles)
                {
                    var role = _roleManager.FindByNameAsync(userRole).Result;
                    if (role != null)
                    {
                        roles.Add(role.Name);
                    }
                }

                representatives.Add(new RepresentativeInfo
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    RoleClaims = roles
                });
            }

            return representatives;
        }

        public bool DeleteRepresentative(string representativeId)
        {
            var user = _userManager.FindByIdAsync(representativeId).Result;
            if (user == null)
            {
                return false;
            }

            // Remove the user from all roles
            var roles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in roles)
            {
                var removeResult = _userManager.RemoveFromRoleAsync(user, role).Result;
                if (!removeResult.Succeeded)
                {
                    var errors = string.Join(", ", removeResult.Errors.Select(e => e.Description));
                    throw new Exception($"Removing user from role failed: {errors}");
                }
            }

            // Delete the user
            var result = _userManager.DeleteAsync(user).Result;
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User deletion failed: {errors}");
            }

            return true;
        }

        public RepresentativeInfo AddRepresentative(RepresentativeInfo representative)
        {
            var user = new ApplicationUser
            {
                UserName = representative.Name,
                Email = representative.Email
            };

            var result = _userManager.CreateAsync(user, "DefaultPassword123!").Result; // Make sure to handle the password properly in production
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User creation failed: {errors}");
            }

            // Ensure roles exist and add the user to the specified roles
            foreach (var role in representative.RoleClaims ?? new List<string>()) // Ensure RoleClaims is not null
            {
                var addRoleResult = _userManager.AddToRoleAsync(user, role).Result;
                if (!addRoleResult.Succeeded)
                {
                    var errors = string.Join(", ", addRoleResult.Errors.Select(e => e.Description));
                    throw new Exception($"Adding user to role '{role}' failed: {errors}");
                }
            }

            return new RepresentativeInfo
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleClaims = representative.RoleClaims
            };
        }

        public List<string> GetAvailableRoles()
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            _logger.LogInformation($"Fetched available roles: {string.Join(", ", roles)}");
            return roles;
        }
    }
}
