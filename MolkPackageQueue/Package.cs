using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    //Package class that contains the priority and the payload.
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

    //Method for setting the priority of the package.
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    //Method for creating a payload that is using GUID.
    public class Payload
    {
        public string Content { get; private set; }

        public Payload()
        {
            Content = GenerateRandomName();
        }

        private string GenerateRandomName()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
