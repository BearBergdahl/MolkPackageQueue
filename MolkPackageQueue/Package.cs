using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    public class Payload 
    {
        public string packageName { get; set; } //Replace with a random name (string of letters) for each instance

        public Payload()
        {
            packageName = GetRandomLetters();
        }

        // Returns a string of random Letters
        public string GetRandomLetters()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] randomLetters = new char[5];
            for (int i = 0; i < 5; i++)
            {
                randomLetters[i] = letters[random.Next(letters.Length)];
            }

            return new string(randomLetters);
        }
    }
   
}
