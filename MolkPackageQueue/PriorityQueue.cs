using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        public static List<Package> proccesedPackage = new List<Package>();

        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        List<Package> ProccesedPackages = new List<Package>();

        public void Enqueue(Package package)
        {
            if(package.Priority == Priority.High)
                queueHigh.Enqueue(package);
            if(package.Priority == Priority.Low)
                queueLow.Enqueue(package);
            if(package.Priority == Priority.Medium)
                queueMedium.Enqueue(package);
        }

        public void Dequeue()
        {
            Random random = new Random();
            int numberOfDequeu = 0;

            while (numberOfDequeu < random.Next(1, 6))
            {
                if (queueHigh.Count > 0)
                {
                    Package packages = queueHigh.Dequeue();
                    AddProccesPackage(packages);
                    Console.WriteLine($"\tPackage sending to Outgoing...{packages.Payload}:{packages.Priority}");
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
                else if (queueMedium.Count > 0)
                {
                    Package packages = queueMedium.Dequeue();
                    AddProccesPackage(packages);
                    Console.WriteLine($"\tPackage sending to Outgoing...{packages.Payload}:{packages.Priority}");
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
                else if (queueLow.Count > 0)
                {
                    Package packages = queueLow.Dequeue();
                    AddProccesPackage(packages);
                    Console.WriteLine($"\tPackage sending to Outgoing...{packages.Payload}:{packages.Priority}");
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
            }
        }

        public void AddProccesPackage(Package package)
        {
            proccesedPackage.Add(package);
        }

        public void ProcessingPackage(List<Package> package)
        {
            foreach (Package p in package)
            {
                Enqueue(p);
            }
            Dequeue();
        }
       
        public void DisplayAllOutgoing()
        {
            int index = 1;
            Console.WriteLine($"Total Outgoing Packages today => {proccesedPackage.Count}");
            foreach(Package package in proccesedPackage)
            {
                Console.WriteLine($"{index} : {package.Payload} : {package.Priority}");
                index++;
            }
        }
    }
}
