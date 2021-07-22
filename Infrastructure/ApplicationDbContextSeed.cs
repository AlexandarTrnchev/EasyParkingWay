using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        /// <summary>
        /// Seeds data in the db.
        /// </summary>
        /// <param name="context">DB Context</param>
        /// <returns></returns>
        public static async Task Seed(ApplicationDbContext context
            /*UserManager<Employee> userManager*/)
        {
            if (!context.Cities.Any())
            {
                var sofia = new City()
                {
                    Name = "Sofia",
                    Created = DateTime.Now
                };

                var plovdiv = new City()
                {
                    Name = "Plovdiv",
                    Created = DateTime.Now,
                };

                var varna = new City()
                {
                    Name = "Varna",
                    Created = DateTime.Now,
                };

                await context.Cities.AddRangeAsync(sofia, plovdiv, varna);
                //await context.SaveChangesAsync(CancellationToken.None);

                var parkingSofia = new Parking()
                {
                    Name = "Parking Sofia",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = sofia
                };

                var parkingPlovdiv = new Parking()
                {
                    Name = "Parking Plovdiv",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = sofia
                };

                var parkingVarna = new Parking()
                {
                    Name = "Parking Varna",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = sofia
                };

                await context.Parkings.AddRangeAsync(parkingSofia, parkingPlovdiv, parkingVarna);

                for (int i = 1; i < 50; i++)
                {
                    var parkingPlaceSofia = new ParkingPlace()
                    {
                        Number = $"Place {i}",
                        Created = DateTime.Now,
                        Parking = parkingSofia,
                        IsFree = true
                    };

                    var parkingPlacePlovdiv = new ParkingPlace()
                    {
                        Number = $"Place {i}",
                        Created = DateTime.Now,
                        Parking = parkingPlovdiv,
                        IsFree = true
                    };

                    var parkingPlaceVarna = new ParkingPlace()
                    {
                        Number = $"Place {i}",
                        Created = DateTime.Now,
                        Parking = parkingVarna,
                        IsFree = true
                    };

                    await context.ParkingPlaces.AddRangeAsync(parkingPlaceSofia, parkingPlacePlovdiv, parkingPlaceVarna);
                }
              
                await context.SaveChangesAsync(CancellationToken.None);
            }
        }
    }
}
