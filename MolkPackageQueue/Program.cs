namespace MolkPackageQueue
{
    class Program
    {
        private static Random randomizer = new Random();
        private static int totalPackagesCreated = 0;

        static void Main(string[] args)
        {
            // Create an instance of your PriorityQueue
            PriorityQueue priorityQueue = new PriorityQueue();

            // Create and enqueue packages
            ProcessPackages(priorityQueue);

            // Display the contents of the lists
            PrintLog(priorityQueue);
        }

        static void ProcessPackages(PriorityQueue priorityQueue)
        {
            PackageFactory factory = new PackageFactory();

            // Loop until at least 50 packages have been created
            while (totalPackagesCreated < 50)
            {
                // Randomly create and enqueue between 1-10 packages
                int packagesToCreate = randomizer.Next(1, 11);
                for (int i = 0; i < packagesToCreate; i++)
                {
                    Package package = factory.CreatePackage();
                    priorityQueue.Enqueue(package);
                    totalPackagesCreated++;
                }

                // Randomly dequeue and process up to 1-5 packages
                int packagesToProcess = randomizer.Next(1, 6);
                for (int i = 0; i < packagesToProcess && !priorityQueue.IsEmpty(); i++)
                {
                    priorityQueue.Dequeue();
                }
            }

            // Continue dequeuing until all queues are empty
            while (!priorityQueue.IsEmpty())
            {
                priorityQueue.Dequeue();
            }
        }

        static void PrintLog(PriorityQueue priorityQueue)
        {
            Console.WriteLine("Packages Created (in order of creation):");
            foreach (var package in priorityQueue.allPackages)
            {
                Console.WriteLine($"Package Name: {package.Payload.PackageName}, Priority: {package.Priority}");
            }

            Console.WriteLine("\nPackages Handled (in processing order):");
            foreach (var package in priorityQueue.dequeuedPackages)
            {
                Console.WriteLine($"Package Name: {package.Payload}, Priority: {package.Priority}");
            }
        }
    }
}
