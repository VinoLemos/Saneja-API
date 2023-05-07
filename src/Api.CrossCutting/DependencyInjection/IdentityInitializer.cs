using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CrossCutting.DependencyInjection
{
    public class IdentityInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRoleSeed _roleSeed;
        private readonly IdentityOptions _identityOptions;

        public IdentityInitializer(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IRoleSeed roleSeed,
            IdentityOptions identityOptions)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleSeed = roleSeed;
            _identityOptions = identityOptions;

            CreateRolesAsync().Wait();
        }

        public async Task CreateRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync(_identityOptions.User.AllowedUserNameCharacters))
                await _roleManager.CreateAsync(new IdentityRole(_identityOptions.User.AllowedUserNameCharacters));

            if (!await _roleManager.RoleExistsAsync("Agent"))
                await _roleManager.CreateAsync(new IdentityRole("Agent"));

            if (!await _roleManager.RoleExistsAsync("Supervisor"))
                await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
        }
    }
}
