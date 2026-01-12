using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp
{
    public class MenuUI
    {
        private IHostService _hostService;

        public MenuUI(IHostService hostService)
        {
            _hostService = hostService;
        }

        public void Run()
        {
            var running = true;

            while (running)
            {
                Console.WriteLine("\n=== BOOKING APP ===");
                Console.WriteLine("1. Show all hosts");
                Console.WriteLine("2. Add new host");
                Console.WriteLine("3. Update host");
                Console.WriteLine("4. Delete host");
                Console.WriteLine("5. Show host apartments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowAllHosts();
                            break;
                        case 2:
                            AddNewHost();
                            break;
                        case 3:
                            UpdateHost();
                            break;
                        case 4:
                            DeleteHost();
                            break;
                        case 5:
                            ShowHostApartments();
                            break;
                        case 0:
                            running = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
        }

        private void ShowAllHosts()
        {
            var hosts = _hostService.GetAllHosts();
            if (!hosts.Any())
            {
                Console.WriteLine("No hosts available.");
                return;
            }

            Console.WriteLine("\n--- All Hosts ---");
            foreach (var host in hosts)
            {
                Console.WriteLine(host);
            }
        }

        private void AddNewHost()
        {
            Console.Write("Enter host name: ");

            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            _hostService.CreateHost(name, new List<Apartment>());
        }

        private void UpdateHost()
        {
            Console.Write("Enter host ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new name: ");
                string? newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine("Name cannot be empty!");
                    return;
                }
                _hostService.UpdateHost(id, newName, null);
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        private void DeleteHost()
        {
            Console.Write("Enter host ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _hostService.DeleteHost(id);
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        private void ShowHostApartments()
        {
            Console.Write("Enter host ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var host = _hostService.GetHostById(id);
                if (host != null)
                {
                    Console.WriteLine($"\nApartments of {host.Name}:");
                    foreach (var apartment in host.Apartments)
                    {
                        Console.WriteLine(apartment);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
    }
}