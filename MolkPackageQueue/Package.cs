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
            Payload = new Payload(Priority);
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2,
        VIP = 3
    }

    public class Payload 
    {
        public string packageName = "EXP0"; //Replace with a random name (string of letters) for each instance
        public static int count = 1; 

        public Payload(Priority priority)
        {           
           packageName = $"Package nr: {count} with {priority} priority, called {packageName}{count}";
            count++;
        }   
    }
}
