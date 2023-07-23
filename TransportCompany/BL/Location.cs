using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.BL
{
    public class Location
    {
        protected string name;
        protected int distance;

        // parameterized constructor
        public Location(string name, int distance)
        {
            this.name = name;
            this.distance = distance;
        }

        public string Name { get => name; }

        public int Distance { get=>  distance; }

        // get name
        public string getName() { return this.name; }

        // get distance
        public int getDistance() { return this.distance;}

        // get to string
        public string toString() { return this.name + ":" + this.distance; }
    }
}
