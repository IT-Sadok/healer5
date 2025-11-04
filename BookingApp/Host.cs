using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingApp
{
    public class Host
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Apartment> Apartments { get; set; }


        public Host(int id, string name, List<Apartment> apartment)
        {
            Id = id;
            Name = name;
            Apartments = apartment;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }

    }
}
