using GeolocationApp.Data;
using GeolocationApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.ComponentModel.DataAnnotations;

namespace GeolocationApp
{
    public static class InitializerSeed
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    context.Database.EnsureCreated(); //Making sure that the db exists

                    var locations = context.Locations.FirstOrDefault();

                    if (locations == null)
                    {
                        //Inserting Users Data
                        context.Users.AddRange(
                            new User { Username = "AndVega", Password = "123456", Email = "andvega@testing.com" },
                            new User { Username = "DanVega", Password = "654321", Email = "danvega@testing.com" },
                            new User { Username = "MajoPz", Password = "789456", Email = "majopz@testing.com" },
                            new User { Username = "GabyCa", Password = "456789", Email = "gabyca@testing.com" }
                            );

                        //Inserting Locations Data
                        context.Locations.AddRange(
                            new Location { UserId = 1, Latitude = -31.41986093114518, Longitude = -64.18850009345307, TimeStamp = Convert.ToDateTime("2023-12-27 10:57:47.754-03").ToUniversalTime() },
                            new Location { UserId = 2, Latitude = -31.391501897549098, Longitude = -64.18482203253495, TimeStamp = Convert.ToDateTime("2023-12-28 12:30:47.754-03").ToUniversalTime() },
                            new Location { UserId = 3, Latitude = -31.42532107560648, Longitude = -64.19287400890026, TimeStamp = Convert.ToDateTime("2023-12-29 17:20:34.651-03").ToUniversalTime() },
                            new Location { UserId = 4, Latitude = -31.419988207614214, Longitude = -64.18571691160005, TimeStamp = Convert.ToDateTime("2023-12-30 05:52:35.696-03").ToUniversalTime() }
                            );

                        //Inserting Places of Interest Data
                        context.Places.AddRange(
                            new PlaceOfInterest { Name = "Lai Café", Latitude = -31.419641300327054, Longitude = -64.18784030263666, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Havanna", Latitude = -31.391501897549098, Longitude = -64.18482203253495, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "MO Bubble Tea", Latitude = -31.42532107560648, Longitude = -64.19287400890026, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Krake Café", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Toppineria", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Pink Café", Latitude = -31.41986093114518, Longitude = -64.18850009345307, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Café de la Plaza", Latitude = -31.391501897549098, Longitude = -64.18482203253495, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Káapeh Cafe", Latitude = -31.42532107560648, Longitude = -64.19287400890026, BusinessType = "coffee shop, cafe" },
                            new PlaceOfInterest { Name = "Me Piacce", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Kantine", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Lomo Lomo", Latitude = -31.41986093114518, Longitude = -64.18850009345307, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Fetuccini", Latitude = -31.391501897549098, Longitude = -64.18482203253495, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Panino", Latitude = -31.42532107560648, Longitude = -64.19287400890026, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Cafelatti Restobar", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Chilli Street Food", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "La Cova del Drac", Latitude = -31.41986093114518, Longitude = -64.18850009345307, BusinessType = "restaurant, bar" },
                            new PlaceOfInterest { Name = "Drugstore Pueyrredon", Latitude = -31.391501897549098, Longitude = -64.18482203253495, BusinessType = "drugstore" },
                            new PlaceOfInterest { Name = "Drugstore Saint George", Latitude = -31.42532107560648, Longitude = -64.19287400890026, BusinessType = "drugstore" },
                            new PlaceOfInterest { Name = "SV FARMA", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "drugstore" },
                            new PlaceOfInterest { Name = "FARMACITY", Latitude = -31.419988207614214, Longitude = -64.18571691160005, BusinessType = "drugstore" }
                            );

                        context.SaveChanges();
                    }

                    return app;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
