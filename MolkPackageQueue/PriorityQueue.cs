using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        //Add Comments
        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        Queue<Package> queue = new Queue<Package>();
        List<Package> finishList = new List<Package>();


        public void Enqueue(Package package)
        {
            Console.WriteLine($"Adding packege to queue.....{package.Priority}");
            if(package.Priority == Priority.High)
                queueHigh.Enqueue(package);
            if(package.Priority == Priority.Low)
                queueLow.Enqueue(package);
            if(package.Priority == Priority.Medium)
                queueMedium.Enqueue(package);
        }
        public void Dequeue(Package package)
        {
            
        }
        public void ProcessingPackage(List<Package> package)
        {
            foreach(Package p in package)
            {
                Console.WriteLine($"Incoming package.......{p.Priority}");
            }
            
            //Console.WriteLine("Sorting package in order by priority");

            //List<Package> SortedList = package.OrderByDescending(o => o.Priority).ToList();

            foreach (Package p in package)
            {
                Enqueue(p);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine($"Proccesing package.....");

                finishList.Add(queue.Dequeue());
            }

            foreach (Package p in finishList)
            {
                Console.WriteLine(p.Priority);
            }

        }
    }
}
