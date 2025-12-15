using System;
using System.Collections.Generic;

namespace BookingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new HostRepository();

            InitializeData(repository);

            var service = new HostService(repository);

            var menu = new MenuUI(service);

            menu.Run();
        }

        private static void InitializeData(HostRepository repository)
        {
            repository.Add(new Host
            {
                Name = "Marlen",
                Apartments = new List<Apartment>
                {
                    new Apartment { Id = 1, Name = "SeaStars" },
                    new Apartment { Id = 2, Name = "Moon Light" }
                }
            });

            repository.Add(new Host
            {
                Name = "David",
                Apartments = new List<Apartment>
                {
                    new Apartment { Id = 1, Name = "Lake Dream" },
                    new Apartment { Id = 2, Name = "Cozy Cabin" }
                }
            });

            repository.Add(new Host
            {
                Name = "Loise",
                Apartments = new List<Apartment>
                {
                    new Apartment { Id = 1, Name = "Forest View" },
                    new Apartment { Id = 2, Name = "City Center Loft" }
                }
            });
        }
    }
}