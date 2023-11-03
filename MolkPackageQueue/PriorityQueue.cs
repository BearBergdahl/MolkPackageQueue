using System;
using System.Collections.Generic;
using System.Linq;

namespace MolkPackageQueue
{
    public class PriorityQueue<T> where T : IPrioritizable
    {
        private readonly Queue<T> highPriorityQueue = new Queue<T>();
        private readonly Queue<T> mediumPriorityQueue = new Queue<T>();
        private readonly Queue<T> lowPriorityQueue = new Queue<T>();

        public void Enqueue(T item)
        {
            // Determine the appropriate internal queue based on priority
            switch (item.Priority)
            {
                case Priority.High:
                    highPriorityQueue.Enqueue(item);
                    break;
                case Priority.Medium:
                    mediumPriorityQueue.Enqueue(item);
                    break;
                case Priority.Low:
                    lowPriorityQueue.Enqueue(item);
                    break;
                default:
                    throw new ArgumentException("Invalid priority value");
            }
        }

        // This should be fine.. probably
        public T Dequeue()
        {
            // First, try to dequeue from high priority queue
            if (highPriorityQueue.Count > 0)
                return highPriorityQueue.Dequeue();

            // Next, try to dequeue from medium priority queue
            if (mediumPriorityQueue.Count > 0)
                return mediumPriorityQueue.Dequeue();

            // Finally, dequeue from low priority queue
            if (lowPriorityQueue.Count > 0)
                return lowPriorityQueue.Dequeue();

            throw new InvalidOperationException("The priority queue is empty.");
        }

        public bool IsEmpty => highPriorityQueue.Count == 0 && mediumPriorityQueue.Count == 0 && lowPriorityQueue.Count == 0;
    }

    public interface IPrioritizable
    {
        Priority Priority { get; }
    }
}