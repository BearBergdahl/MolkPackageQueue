using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        public List<Package> packagesCreatedLog = new List<Package>();
        public List<Package> packagesHandledLog = new List<Package>();
        private Queue<Package> queueHigh = new Queue<Package>();
        private Queue<Package> queueMedium = new Queue<Package>();
        private Queue<Package> queueLow = new Queue<Package>();

        public void Enqueue(Package package)
        {
            packagesCreatedLog.Add(package);
            switch (package.Priority)
            {
                case Priority.Low:
                    queueLow.Enqueue(package); 
                    break;
                case Priority.Medium: 
                    queueMedium.Enqueue(package);
                    break;
                case Priority.High:
                    queueHigh.Enqueue(package);
                    break;
                default:
                    break;
            }
        }
        public void Dequeue()
        {
            Package package;
            if (queueHigh.Count > 0)
            {
                package = queueHigh.Dequeue();
                packagesHandledLog.Add(package);
            }
            else if (queueMedium.Count > 0) 
            {
                package = queueMedium.Dequeue();
                packagesHandledLog.Add(package);
            }
            else if (queueLow.Count > 0)
            {
                package = queueLow.Dequeue();
                packagesHandledLog.Add(package);
            }
        }
    }
}
