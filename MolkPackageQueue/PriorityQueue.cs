using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        private Queue<Package> queueHigh = new Queue<Package>();
        private Queue<Package> queueMedium = new Queue<Package>();
        private Queue<Package> queueLow = new Queue<Package>();

        public List<Package> allPackages = new List<Package>();
        public List<Package> dequeuedPackages = new List<Package>(); // Second list for dequeued packages

        public void Enqueue(Package package)
        {

            allPackages.Add(package);

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
            Package package = null;

            // Remove and return a package from the highest-priority non-empty queue
            if (queueHigh.Count > 0)
            {
                package = queueHigh.Dequeue();
            }
            else if (queueMedium.Count > 0)
            {
                package = queueMedium.Dequeue();
            }
            else if (queueLow.Count > 0)
            {
                package = queueLow.Dequeue();
            }

            if (package != null)
            {
                // Add the dequeued package to the list of dequeued packages
                dequeuedPackages.Add(package);

                return package;
            }
            else
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }
        }

        // Method to check if the priority queue is empty
        public bool IsEmpty()
        {
            return queueHigh.Count == 0 && queueMedium.Count == 0 && queueLow.Count == 0;
        }
    }
}

