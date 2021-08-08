namespace SharedBook.Infrastructure
{
    using System.IO;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using SharedBook.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<SharedBookDbContext>();

            data.Database.Migrate();

            SeedLocations(data);

            return app;
        }

        private static void SeedLocations(SharedBookDbContext data)
        {
            if (data.Books.Any())
            {
                return;
            }
            
            var citiesJson = File.ReadAllText("Infrastructure/bgCities.json");

            var jsonLocations = JsonConvert.DeserializeObject<Location[]>(citiesJson);

            foreach (var location in jsonLocations)
            {
                data.Locations.Add(location);
            }

            data.SaveChanges();
        }
    }
}
