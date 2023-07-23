using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.BL
{
    internal class Vehicle
    {
        protected string name;
        protected int costIndex;

        // parameterized constructor
        public Vehicle(string name, int costIndex)
        {
            this.name = name;
            this.costIndex = costIndex;
        }

        public string Name { get=> name;}
        public int Cost_Index { get=> costIndex;}

        // get name
        public string getName() { return this.name; }

        // get price per distance unit
        public int getCostIndex() { return this.costIndex; }

        // set cost index
        public void setCostIndex(int costIndex) {  this.costIndex = costIndex; }
    }
}
