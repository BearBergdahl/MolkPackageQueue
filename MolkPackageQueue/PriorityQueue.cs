using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        public void Enqueue(Package package)
        {
            switch (package.Priority)
            {
                case Priority.High:
                    queueHigh.Enqueue(package);
                    break;
                case Priority.Medium:
                    queueMedium.Enqueue(package);
                    break;
                case Priority.Low:
                    queueLow.Enqueue(package);
                    break;
            }
        }
        public Package Dequeue()
        {
            if (queueHigh.Count > 0)
            {
                return queueHigh.Dequeue();
            }
            else if (queueMedium.Count > 0)
            {
                return queueMedium.Dequeue();
            }
            else if (queueLow.Count > 0)
            {
                return queueLow.Dequeue();
            }
            else
            {
                throw new InvalidOperationException("No packages are available in the queue.");
            }
        }

        public bool HasPackages()
        {
            return queueHigh.Count > 0 || queueMedium.Count > 0 || queueLow.Count > 0;
        }
    }
}
