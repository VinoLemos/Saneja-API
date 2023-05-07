using Microsoft.AspNetCore.Identity;

public class DefaultRoleSeed : IRoleSeed
{
    public async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Person")) await roleManager.CreateAsync(new IdentityRole("Person"));
        if (!await roleManager.RoleExistsAsync("Agent")) await roleManager.CreateAsync(new IdentityRole("Agent"));
        if (!await roleManager.RoleExistsAsync("Supervisor")) await roleManager.CreateAsync(new IdentityRole("Supervisor"));
    }
}
