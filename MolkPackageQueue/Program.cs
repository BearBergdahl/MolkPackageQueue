using System;

namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Implementing MPS...");
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();

            PriorityQueue<Package> priorityQueue = new PriorityQueue<Package>();
            PackageFactory factory = new PackageFactory();
            Random random = new Random();

            int packagesCreated = 0;
            while (packagesCreated < 50)
            {
                int toCreate = random.Next(1, 11);
                for (int i = 0; i < toCreate && packagesCreated < 50; i++)
                {
                    Package package = factory.CreatePackage();
                    priorityQueue.Enqueue(package, package.Priority);
                    packagesCreated++;
                }

                int toDequeue = random.Next(1, 6);
                for (int i = 0; i < toDequeue; i++)
                {
                    priorityQueue.Dequeue();
                }
            }

            while (priorityQueue.OutgoingLog.Count < packagesCreated)
            {
                priorityQueue.Dequeue();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---------------- Packages Created: ----------------");
            Console.ResetColor();
            foreach (var package in priorityQueue.IncomingLog)
            {
                Console.WriteLine($"Priority: {package.Priority}, Payload Name: {package.Payload.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n---------------- Packages Handled: ----------------");
            Console.ResetColor();
            foreach (var package in priorityQueue.OutgoingLog)
            {
                Console.WriteLine($"Priority: {package.Priority}, Payload Name: {package.Payload.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMPS Implementation Completed!");
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
        }
    }
}
