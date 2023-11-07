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
            if (queueHigh.Any())
            {
                return queueHigh.Dequeue();
            }
            else if (queueMedium.Any())
            {
                return queueMedium.Dequeue();
            }
            else if (queueLow.Any())
            {
                return queueLow.Dequeue();
            }
            return null; // If there is no packages to dequeue
        }
    }
}
