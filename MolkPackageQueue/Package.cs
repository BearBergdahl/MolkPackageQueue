using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        High = 2,
    }

    public class Payload
    {
        private static Random randomizer = new Random();
        public string PackageName { get; private set; }


        public Payload()
        {
            PackageName = GenerateRandomName(10); // Generates a random name of 10 characters
        }

        private static string GenerateRandomName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";            
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randomizer.Next(s.Length)]).ToArray());
        }
    }
}