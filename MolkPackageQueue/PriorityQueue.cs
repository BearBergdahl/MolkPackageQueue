using System.Collections.Generic;

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

            return null;
        }
    }
}
