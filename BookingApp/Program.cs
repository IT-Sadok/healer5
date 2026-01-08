using System;
using System.Collections.Generic;

namespace BookingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostRepository repository = new HostRepository();
            ILogger logger = new ConsoleLogger();

            InitializeData(repository);

            IHostService service = new HostService(repository, logger);
            MenuUI menu = new MenuUI(service);

            menu.Run();
        }

        private static void InitializeData(IHostRepository repository)
        {
            repository.Add(new Host
            {
                Name = "Marlen",
                Apartments = new List<Apartment>
                {
                    new Apartment {Name = "SeaStars" },
                    new Apartment {Name = "Moon Light" }
                }
            });

            repository.Add(new Host
            {
                Name = "David",
                Apartments = new List<Apartment>
        {
            new Apartment {Name = "Lake Dream" },
            new Apartment {Name = "Cozy Cabin" }
        }
            });

            repository.Add(new Host
            {
                Name = "Loise",
                Apartments = new List<Apartment>
        {
            new Apartment {Name = "Forest View" },
            new Apartment {Name = "City Center Loft" }
        }
            });
        }
    }
}