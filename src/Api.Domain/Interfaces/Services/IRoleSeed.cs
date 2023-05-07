using Microsoft.AspNetCore.Identity;

public interface IRoleSeed
{
    Task SeedRolesAsync(RoleManager<IdentityRole> roleManager);
}
