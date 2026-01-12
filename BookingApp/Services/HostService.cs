using System;
using System.Collections.Generic;

namespace BookingApp
{
    public interface IHostService
    {
        void CreateHost(string name, List<Apartment> apartments);
        IEnumerable<Host> GetAllHosts();
        Host? GetHostById(int id);
        void UpdateHost(int id, string newName, List<Apartment> newApartments);
        void DeleteHost(int id);
    }
    public class HostService : IHostService
    {
        private readonly IHostRepository _repository;
        private readonly ILogger _logger;

        public HostService(IHostRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
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
            _logger.Log($"Host '{name}' created successfully!");
        }

        public IEnumerable<Host> GetAllHosts()
        {
            return _repository.GetAll();
        }

        public Host? GetHostById(int id)
        {
            var host = _repository.GetById(id);
            if (host == null)
            {
                _logger.Log("Host not found!");
            }
            return host;
        }

        public void UpdateHost(int id, string newName, List<Apartment> newApartments)
        {
            var host = _repository.GetById(id);
            if (host == null)
            {
                _logger.Log("Host not found!");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                _logger.Log("Name cannot be empty!");
                return;
            }

            host.Name = newName;
            host.Apartments = newApartments ?? host.Apartments;
            _repository.Update(host);
        }

        public void DeleteHost(int id)
        {
            if (_repository.Delete(id))
            {
                _logger.Log("Host deleted successfully!");
            }
            else
            {
                _logger.Log("Host not found!");
            }
        }
    }
}