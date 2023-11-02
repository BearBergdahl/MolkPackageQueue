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

        List<Package> proccesedPackage = new List<Package>();


        public void Enqueue(Package package)
        {
            if(package.Priority == Priority.High)
                queueHigh.Enqueue(package);
            if(package.Priority == Priority.Low)
                queueLow.Enqueue(package);
            if(package.Priority == Priority.Medium)
                queueMedium.Enqueue(package);
        }
        public void Dequeue(Package package)
        {
            proccesedPackage.Add(package);
            Console.WriteLine($"Proccesing package {package.Payload} is complete");
        }
        public void ProcessingPackage(List<Package> package)
        {

            foreach (Package p in package)
            {
                Enqueue(p);
            }
            DisplayList(queueHigh);
            DisplayList(queueMedium);
            DisplayList(queueLow);


            //while (queue.Count > 0)
            //{
            //    Console.WriteLine($"Proccesing package.....");

            //    finishList.Add(queue.Dequeue());
            //}

            //foreach (Package p in finishList)
            //{
            //    Console.WriteLine(p.Priority);
            //}
        }
        public void ProcessPackage()
        {
            if (queueHigh.Count < 0)
            {
                queueHigh.Dequeue();
                foreach (Package p in queueHigh)
                {
                    Dequeue(p);
                    
                }
            }
            else if (queueMedium.Count < 0)
            {
                foreach (Package p in queueMedium)
                {
                    Dequeue(p);
                }
            }
            else if (queueLow.Count < 0)
            {
                foreach (Package p in queueLow)
                {
                    Dequeue(p);
                }
            }
            else
                Console.WriteLine("No more packaged to process");
                
        }
        public void DisplayList(Queue<Package> packages)
        {
            int index = 1;
            foreach(Package p in packages)
            {
                Console.WriteLine($"{index} : {p.Priority}");
                index++;
            }
        }
    }
}
