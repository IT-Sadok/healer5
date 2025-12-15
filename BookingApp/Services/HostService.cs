using System;
using System.Collections.Generic;

namespace BookingApp
{
    public class HostService
    {
        private HostRepository _repository;

        public HostService(HostRepository repository)
        {
            _repository = repository;
        }

        public void CreateHost(string name, List<Apartment> apartments)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Host name cannot be empty!");
            }

            var host = new Host
            {
                Name = name,
                Apartments = apartments ?? new List<Apartment>()
            };

            _repository.Add(host);
            Console.WriteLine($"Host '{name}' created successfully!");
        }

        public List<Host> GetAllHosts()
        {
            return _repository.GetAll();
        }

        public Host GetHostById(int id)
        {
            var host = _repository.GetById(id);
            if (host == null)
            {
                Console.WriteLine("Host not found!");
            }
            return host;
        }

        public void UpdateHost(int id, string newName, List<Apartment> newApartments)
        {
            var host = _repository.GetById(id);
            if (host == null)
            {
                Console.WriteLine("Host not found!");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            host.Name = newName;
            host.Apartments = newApartments ?? host.Apartments;

            _repository.Update(host);
            Console.WriteLine("Host updated successfully!");
        }

        public void DeleteHost(int id)
        {
            if (_repository.Delete(id))
            {
                Console.WriteLine("Host deleted successfully!");
            }
            else
            {
                Console.WriteLine("Host not found!");
            }
        }
    }
}