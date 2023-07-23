using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DL;
using TransportCompany.UI;

namespace TransportCompany.BL
{
    public class Admin : Person
    {


        // parameterized sonstructor
        public Admin(string name, string password, string role, City city, string address) : base(name, password, role, city, address) { }

    }
}
