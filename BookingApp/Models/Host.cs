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
        public required string Name { get; set; }

        public List<Apartment> Apartments { get; set; } = new List<Apartment>();

        public override string ToString() => $"{Id}. {Name}";
    }
}
