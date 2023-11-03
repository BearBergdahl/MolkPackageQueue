using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue<T>
    {
        private Queue<T> queueHigh = new Queue<T>();
        private Queue<T> queueMedium = new Queue<T>();
        private Queue<T> queueLow = new Queue<T>();

        //Method that adds a package to the queue, depending on which priority the package has.
        public void Enqueue(Priority priority, T item)
        {
            switch (priority)
            {
                case Priority.High:
                    queueHigh.Enqueue(item);
                    break;
                case Priority.Medium:
                    queueMedium.Enqueue(item);
                    break;
                case Priority.Low:
                    queueLow.Enqueue(item);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(priority), priority, null);
            }
        }
        // Method that removes a package from the queue, depending on which priority the package has.
        // Added a console.writeline to see which queue the package is taken from.
        public T Dequeue()
        {
            if (queueHigh.Count > 0)
            {
                Console.WriteLine("Taking package from High Priority Queue.");
                return queueHigh.Dequeue();
            }

            if (queueMedium.Count > 0)
            {
                Console.WriteLine("High Priority Queue is empty. Taking package from Medium Priority Queue.");
                return queueMedium.Dequeue();
            }

            if (queueLow.Count > 0)
            {
                Console.WriteLine("High and Medium Priority Queues are empty. Taking package from Low Priority Queue.");
                return queueLow.Dequeue();
            }

            throw new InvalidOperationException("All priority queues are empty.");
        }


        public int Count
        {
            get { return queueHigh.Count + queueMedium.Count + queueLow.Count; }
        }
    }
}
