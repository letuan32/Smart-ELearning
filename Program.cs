using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Smart_ELearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //var context = services.GetRequiredService<ApplicationDbContext>();
                    //var userManager = services.GetRequiredService<UserManager<AppUserModel>>();
                    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    //await Seed.ContextSeed.SeedRolesAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    //var logger = loggerFactory.CreateLogger<Program>();
                    //logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}