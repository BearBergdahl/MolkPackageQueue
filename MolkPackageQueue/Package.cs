using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        private static Random random = new Random();

        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload(GenerateRandomName());
        }
        public Priority Priority { get; }
        public Payload Payload { get; }

        private static string GenerateRandomName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    public class Payload
    {
        public string PackageName { get; }

        public Payload(string packageName)
        {
            PackageName = packageName;
        }
    }
}