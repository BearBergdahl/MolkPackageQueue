using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{

    public class Package
    {
        public Priority Priority { get; }
        private Payload Payload { get; }

        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }

        public override string ToString()
        {
            return $"{Payload} with {Priority} priority";
        }
    }

    public class Payload 
    {
        private static int count = 1;
        private string PackageName { get; }

        public Payload()
        {
            PackageName = "Package nr: " + count;
            count++;
        }

        public override string ToString()
        {
            return $"{PackageName}";
        }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }
}
