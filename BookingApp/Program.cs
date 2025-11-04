using System;

namespace BookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Host> hosts = new List<Host>();

            hosts.Add(new Host(1, "Marlen", new List<Apartment> {
                    new Apartment(1, "SeaStars"),
                    new Apartment(2, "Moon Light")
                }));
            hosts.Add(new Host(2, "David", new List<Apartment> {
                new Apartment(1, "Lake Dream"),
                new Apartment(2, "Cozy Cabin")
            }));
            hosts.Add(new Host(3, "Loise", new List<Apartment> {
                new Apartment(1, "Forest View"),
                new Apartment(2, "City Center Loft")
            }));
          

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


