using FastDostavka.Data.Entities.IdentityUser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data.Seeed
{
    public class SeedData
    {
        public static async Task SeedAsync(IServiceProvider services, IWebHostEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //context.Database.Migrate();
                PreConfigured.SeedRoles(managerRole);
                await PreConfigured.SeedUsersAsync(manager, context);
            }
        }
    }
}
