using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue<T>
    {
        public Queue<T> queueHigh = new Queue<T>();
        public Queue<T> queueMedium = new Queue<T>();
        public Queue<T> queueLow = new Queue<T>();


        public void Enqueue(T package)
        {
            var packageItem = package as Package;
            if (packageItem == null) throw new ArgumentException("Invalid package type");

            if (packageItem.Priority == Priority.Low)
            {
                queueLow.Enqueue(package);
            }
            else if (packageItem.Priority == Priority.Medium)
            {
                queueMedium.Enqueue(package);
            }
            else
            {
                queueHigh.Enqueue(package);
            }
        
        }


        public T Dequeue()
        {
            if (queueHigh.Count >0)
            {
                return queueHigh.Dequeue();
            }
            else if(queueMedium.Count >0)
            {
                return queueMedium.Dequeue();
            }
            else if (queueLow.Count >0)
            {
                return queueLow.Dequeue();
            }
            else
            {
                throw new InvalidOperationException("All queues are empty.");
            }
        }
    }
}
