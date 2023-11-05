namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Implement MPS");
            // Instantiate the MPS-PriorityQueue
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.

            Console.WriteLine("Molk Package System starting...");

            PriorityQueue priorityQueue = new PriorityQueue();
            PackageFactory factory = new PackageFactory();
            List<Package> incomingLog = new List<Package>();
            List<Package> handledLog = new List<Package>();

            Random random = new Random();
            int packageCount = 0;

            // The main loop for creating and processing packages
            while (packageCount < 50)
            {
                int packagesToCreate = random.Next(1, 11); // Create 1-10 packages
                for (int i = 0; i < packagesToCreate && packageCount < 50; i++)
                {
                    Package package = factory.CreatePackage();
                    priorityQueue.Enqueue(package);
                    incomingLog.Add(package);
                    packageCount++;
                }

                int packagesToProcess = random.Next(1, 6); // Process 1-5 packages
                for (int i = 0; i < packagesToProcess; i++)
                {
                    Package handledPackage = priorityQueue.Dequeue();
                    if (handledPackage != null)
                    {
                        handledLog.Add(handledPackage);
                    }
                    else
                    {
                        break; // No more packages to process
                    }
                }
            }

            // Continue processing until all queues are empty
            Package remainingPackage;
            while ((remainingPackage = priorityQueue.Dequeue()) != null)
            {
                handledLog.Add(remainingPackage);
            }

            // Prints incoming packages
            Console.WriteLine("\nIncoming Packages:");
            foreach (var package in incomingLog)
            {
                Console.WriteLine($"Package Name: {package.Payload.PackageName}, Priority: {package.Priority}");
            }

            // Prints handled packages
            Console.WriteLine("\nHandled Packages:");
            foreach (var package in handledLog)
            {
                Console.WriteLine($"Package Name: {package.Payload.PackageName}, Priority: {package.Priority}");
            }

            Console.WriteLine("Molk Package System completed.");
        }
    }
}