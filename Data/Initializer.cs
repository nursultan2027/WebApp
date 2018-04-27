using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public static class initializer
    {
        public static async Task initial(RoleManager <IdentityRole> roleManeger)
        {
            if (!await roleManeger.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await roleManeger.CreateAsync(users);
            }
            if (!await roleManeger.RoleExistsAsync("User"))
            {
                var users = new IdentityRole("User");
                await roleManeger.CreateAsync(users);
            }
            if (!await roleManeger.RoleExistsAsync("Menager"))
            {
                var users = new IdentityRole("Menager");
                await roleManeger.CreateAsync(users);
            }
        }
    }
}