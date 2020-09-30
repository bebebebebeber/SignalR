using FastDostavka.Data.Entities.IdentityUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data.Seeed
{
    public class PreConfigured
    {
        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    string roleName = "User";
                    var result = roleManager.CreateAsync(new DbRole
                    {
                        
                        Name = roleName
                    }).Result;
                    roleName = "Admin";
                    var result2 = roleManager.CreateAsync(new DbRole
                    {
                        
                        Name = roleName
                    }).Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static async Task SeedUsersAsync(UserManager<DbUser> userManager, ApplicationDbContext context)
        {
            try
            {
                if (!context.Users.Any())
                {
                    DbUser user1 = new DbUser
                    {
                        UserName = "beedirector",
                        Email = "beedirector@gmail.com",
                        PhoneNumber = "+380503334031",
                    };
                    DbUser user2 = new DbUser
                    {
                        UserName = "green.slonik",
                        Email = "green.slonik@gmail.com",
                        PhoneNumber = "+380505551541",
                    };


                    await userManager.CreateAsync(user1, "Qwerty-1");
                    await userManager.AddToRoleAsync(user1, "Admin");

                    await userManager.CreateAsync(user2, "Qwerty-1");
                    await userManager.AddToRoleAsync(user2, "Admin");

                }
               
            }
            catch (Exception ex)
            {

            }


        }
    }
}
