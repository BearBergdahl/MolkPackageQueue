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
        List<Package> outgoingPackages = new List<Package>();

        // Enqueue packages based on its priority
        public void Enqueue(Package package)
        {
            if(package.Priority == Priority.High)
                queueHigh.Enqueue(package);
            if(package.Priority == Priority.Low)
                queueLow.Enqueue(package);
            if(package.Priority == Priority.Medium)
                queueMedium.Enqueue(package);
        }

        // Dequeue random number of packages every time its called, removes a system check varibles value by number of dequeu packages
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
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
                else if (queueMedium.Count > 0)
                {
                    Package packages = queueMedium.Dequeue();
                    AddProccesPackage(packages);
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
                else if (queueLow.Count > 0)
                {
                    Package packages = queueLow.Dequeue();
                    AddProccesPackage(packages);
                    numberOfDequeu++;
                    Program.numberOfOrderProcessed--;
                }
            }
        }

        // Adds all outgoing packages to a list of proccesed packages
        public void AddProccesPackage(Package package)
        {
            Console.WriteLine($"\tPackage sending to Outgoing...{package.Payload}:{package.Priority}");
            outgoingPackages.Add(package);
        }

        // Handels the procces of sending package to Enqueue and starts a Dequeu while running!
        public void ProcessingPackage(List<Package> package)
        {
            foreach (Package p in package)
            {
                Enqueue(p);
            }
            Dequeue();
        }
       
        // Displays all Outgoing packages in list
        public void DisplayAllOutgoing()
        {
            int index = 1;
            Console.WriteLine($"Total Outgoing Packages today => {outgoingPackages.Count}");
            foreach(Package package in outgoingPackages)
            {
                Console.WriteLine($"{index} : {package.Payload} : {package.Priority}");
                index++;
            }
        }
    }
}
