using System;
using System.Collections.Generic;

namespace MolkPackageQueue
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  *** PACKAGES *** \n");
            PackageFactory packageFactory = new PackageFactory();
            PriorityQueue priorityQueue = new PriorityQueue();
            for (int i = 0; i < 50; i++)
            {
                Package myPackage = packageFactory.CreatePackage();
                priorityQueue.PutPackageInQueue(myPackage);
                // Console.WriteLine(myPackage.Payload.packageName);               
            }
            Console.WriteLine(" [Enqued 50 packages]");
            for (int j = 0; j < 50; j++)
            {             
                priorityQueue.RemovePackageFromQueue();              
            }
            Console.WriteLine(" [Dequed 50 packages]");


            // Instantiate the MPS-PriorityQueue
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
        }
    }
}