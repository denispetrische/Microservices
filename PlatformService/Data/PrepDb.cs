using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System.Linq;
using System;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Data");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dotnet", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "MicrosoftServerExpress", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computer Foundation", Cost = "Free"}
                    ); ;

                context.SaveChanges();
            }
            else
            { 
                Console.WriteLine("---> Data already in Db");
            }
        }
    }
}
