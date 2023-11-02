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
        private static Random random = new Random();
        public string PackageName { get; private set; }

        public Payload()
        {
            PackageName = GenerateRandomName();
        }

        private string GenerateRandomName(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }


}
