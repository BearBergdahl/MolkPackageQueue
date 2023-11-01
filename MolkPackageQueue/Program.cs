using System;
using System.Collections.Generic;

namespace MolkPackageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Package> incomingPackages = new List<Package>();
            List<Package> outgoingPackages = new List<Package>();
            PriorityQueue priorityQueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();

            int totalPackages = 0;

            while (totalPackages < 50)
            {
                int packagesToCreate = new Random().Next(1, 11);
                for (int i = 0; i < packagesToCreate; i++)
                {
                    Package newPackage = packageFactory.CreatePackage();
                    priorityQueue.Enqueue(newPackage);
                    incomingPackages.Add(newPackage);
                }
                totalPackages += packagesToCreate;

                int packagesToDequeue = new Random().Next(1, 6);
                for (int i = 0; i < packagesToDequeue; i++)
                {
                    Package dequeuedPackage = priorityQueue.Dequeue();
                    if (dequeuedPackage != null)
                    {
                        outgoingPackages.Add(dequeuedPackage);
                    }
                }
            }

            while (true)
            {
                Package dequeuedPackage = priorityQueue.Dequeue();
                if (dequeuedPackage == null)
                {
                    break;
                }
                outgoingPackages.Add(dequeuedPackage);
            }

            Console.WriteLine("Inkommande ordning:");
            foreach (var package in incomingPackages)
            {
                Console.WriteLine($"Prio: {package.Priority}, Payload: {package.Payload.Empty}");
            }

            Console.WriteLine("Utgående ordning:");
            foreach (var package in outgoingPackages)
            {
                Console.WriteLine($"Prio: {package.Priority}, Payload: {package.Payload.Empty}");
            }
        }
    }
}
