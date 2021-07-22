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

                var burgas = new City()
                {
                    Name = "Burgas",
                    Created = DateTime.Now
                };

                var ruse = new City()
                {
                    Name = "Ruse",
                    Created = DateTime.Now
                };

                var blgrad = new City()
                {
                    Name = "Blagoevgrad",
                    Created = DateTime.Now
                };
                await context.Cities.AddRangeAsync(sofia, plovdiv, varna, burgas, ruse, blgrad);
                //await context.SaveChangesAsync(CancellationToken.None);

                var parkingSofia_1 = new Parking()
                {
                    Name = "Parking Sofia_1",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = sofia
                };

                var parkingSofia_2 = new Parking()
                {
                    Name = "Parking Sofia_2",
                    Created = DateTime.Now,
                    Address = "some street 28",
                    City = sofia
                };

                var parkingSofia_3 = new Parking()
                {
                    Name = "Parking Sofia_3",
                    Created = DateTime.Now,
                    Address = "some street 30",
                    City = sofia
                };

                var parkingPlovdiv = new Parking()
                {
                    Name = "Parking Plovdiv",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = plovdiv
                };

                var parkingVarna = new Parking()
                {
                    Name = "Parking Varna",
                    Created = DateTime.Now,
                    Address = "some street 29",
                    City = varna
                };

                await context.Parkings.AddRangeAsync(parkingSofia_1, parkingSofia_2, parkingSofia_3, parkingPlovdiv, parkingVarna);

                for (int i = 1; i < 50; i++)
                {
                    var parkingPlaceSofia = new ParkingPlace()
                    {
                        Number = $"Place {i}",
                        Created = DateTime.Now,
                        Parking = i % 2 == 0 ? parkingSofia_1 : parkingSofia_2,
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
