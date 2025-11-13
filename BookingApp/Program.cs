using System;
using System.Xml.Linq;

namespace BookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Host> hosts = new List<Host>();

            hosts.Add(new Host
            {
                Id = 1, 
                Name = "Marlen", 
                Apartments = new List<Apartment> {
                    new Apartment{Id = 1, Name = "SeaStars"},
                    new Apartment { Id = 2, Name = "Moon Light"}
                }
            });

            hosts.Add(new Host{Id = 2, Name = "David",
                Apartments = new List<Apartment> {
                new Apartment{Id = 1, Name = "Lake Dream"},
                new Apartment
                {
                    Id = 2, Name = "Cozy Cabin"}
   }
            });
            hosts.Add(new Host
            {
                Id = 3, 
                Name = "Loise",
                Apartments = new List<Apartment> {
                new Apartment{Id = 1, Name = "Forest View"},
                new Apartment
                {
                    Id = 2, Name = "City Center Loft"}
    }
            });
          

            foreach (Host name in hosts)
            {
                Console.WriteLine(name);
            }


            if (int.TryParse(Console.ReadLine(), out int idFromUser))
            {
                Host selectedHost = hosts.FirstOrDefault(h => h.Id == idFromUser);

                if (selectedHost != null)
                {
                    foreach (Apartment apartment in selectedHost.Apartments)
                    {
                        Console.WriteLine(apartment);
                    }
                }
                else
                {
                    Console.WriteLine("No host with this ID found!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }
    }
 }


