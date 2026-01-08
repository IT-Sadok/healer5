using System.Collections.Generic;
using System.Linq;

namespace BookingApp
{
    public interface IHostRepository
    {
        void Add(Host host);
        IEnumerable<Host> GetAll();
        Host? GetById(int id);
        bool Update(Host host);
        bool Delete(int id);
    }
    public class HostRepository : IHostRepository
    {
        private List<Host> _hosts = new List<Host>();
        private int _nextId = 1;

        public void Add(Host host)
        {
            host.Id = _nextId++;
            _hosts.Add(host);
        }

        public IEnumerable<Host> GetAll()
        {
            return _hosts;
        }

        public Host? GetById(int id)
        {
            return _hosts.FirstOrDefault(h => h.Id == id);
        }

        public bool Update(Host updatedHost)
        {
            var host = GetById(updatedHost.Id);
            if (host != null)
            {
                host.Name = updatedHost.Name;
                host.Apartments = updatedHost.Apartments;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var host = GetById(id);
            if (host != null)
            {
                _hosts.Remove(host);
                return true;
            }
            return false;
        }
    }
}