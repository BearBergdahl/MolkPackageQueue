using System.Collections.Generic;

namespace MolkPackageQueue
{
    public class PriorityQueue<T>
    {
        private Queue<T> queueHigh = new Queue<T>();
        private Queue<T> queueMedium = new Queue<T>();
        private Queue<T> queueLow = new Queue<T>();

        public List<T> IncomingLog { get; private set; } = new List<T>();
        public List<T> OutgoingLog { get; private set; } = new List<T>();

        public void Enqueue(T package, Priority priority)
        {
            IncomingLog.Add(package);

            switch (priority)
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

        public T? Dequeue()
        {
            T? package = default(T);

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
                OutgoingLog.Add(package);
            }
            return package;
        }
    }
}
