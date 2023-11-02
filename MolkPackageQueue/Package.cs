using System.Linq;

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
        public string Name { get; }

        public Payload()
        {
            Name = GenerateRandomName();
        }

        private string GenerateRandomName()
        {
            Random random = new Random();
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
