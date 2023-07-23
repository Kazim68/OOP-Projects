using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.UI
{
    internal class Input
    {
        // return a string
        public static string stringInput(string message)
        {
            Console.Write(message);
            return noComma();
        }

        // check for any invalid inputs
        public static bool ValidString(string text)
        {
            if (text.Trim() == string.Empty || text.Contains(","))
            {
                return false;
            }
            return true;
        }

        // comma validation
        public static string noComma()
        {
            do
            {
                string input = Console.ReadLine();
                if (!input.Contains(',')) { return  input; }
                Console.WriteLine("Invalid Input!");
            } while (true);
        }

        // return int input
        public static int intInput(string message) 
        {
            do
            {
                string input = stringInput(message);
                int num;
                if (int.TryParse(input, out num)) { return num; }
                Console.WriteLine("Invalid Input!");
            }
            while (true);
        }

        // valid int only allows postive numbers within a range
        public static bool validInt(string number, int range)
        {
            int num;
            if (int.TryParse(number, out num))
            {
                if (num <= range && num > 0 )
                    { return true; } 
            }
            return false;  
        }

        // return new password
        public static string newPassword()
        {
            do
            {
                string p1 = Input.stringInput("Enter new Password: ");
                string p2 = Input.stringInput("Re-Enter new Password: ");
                if (p1 == p2) { return p1; }
                Console.WriteLine("Password does not match! Re-Enter");
            } while (true);
        }

        // take user choice input
        public static string Option()
        {
            return stringInput("Enter your choice: ");
        }
    }
}
