using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package : IPrioritizable
    {
        /// <summary>
        /// Represents a package with a specified priority level and payload.
        /// </summary>
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
            CreatedTimestamp = DateTime.Now; // Add created timestamp
        }

        public Priority Priority { get; set; }
        public Payload Payload { get; }
        public DateTime CreatedTimestamp { get; }
        public DateTime? SentTimestamp { get; set; }
    }

    /// <summary>
    /// Represents the priority levels for packages.
    /// </summary>
    public enum Priority 
    { 
        High,
        Medium,
        Low
    }

    public class Payload
    {
        public string PackageName { get; }

        public Payload()
        {
            PackageName = RandomUtility.GenerateRandomName(10);
        }
    }
}
