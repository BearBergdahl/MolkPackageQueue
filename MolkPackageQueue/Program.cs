using System.Diagnostics;

namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Implement MPS");
            // Instantiate the MPS-PriorityQueue
            PriorityQueue priorityQueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();
            // Don´t forget the logging lists
            List<Package> incomingPackages = new List<Package>();
            List<Package> completedPackages = new List<Package>();
            // Create a function to queue and dequeue packages according to the rules.
            ProcessPackages(priorityQueue, incomingPackages, completedPackages, packageFactory);

            // Print log for packages created in order of creation, with payload packageName and package priority
            Console.WriteLine("Incoming packages:");
            foreach (var package in incomingPackages)
            {
                Console.WriteLine($"Package: {package.Payload.PackageName}, Priority: {package.Priority}");
            }

            // Print log for packages handled (dequeue and add to logg), same content as above.
            Console.WriteLine("\nHandled packages:");
            foreach (var package in completedPackages)
            {
                Console.WriteLine($"Package: {package.Payload.PackageName}, Priority: {package.Priority}");
            }
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
        }

        private static void ProcessPackages(PriorityQueue priorityQueue, List<Package> incomingPackages, List<Package> completedPackages, PackageFactory packageFactory)
        {
            int totalPackagesCreated = 0;
            Random randomizer = new Random();

            while (totalPackagesCreated < 50)
            {
                //Create 1-10 packages
                int packagesToCreate = randomizer.Next(1, 11);
                Debug.WriteLine($"Creating {packagesToCreate} packages");
                for (int i = 0; i < packagesToCreate; i++)
                {
                    Package package = packageFactory.CreatePackage();
                    priorityQueue.Enqueue(package);
                    incomingPackages.Add(package);
                }
                totalPackagesCreated += packagesToCreate;

                //Dequeue 1-5 packages
                int packagesToProcess = randomizer.Next(1, 6);
                Debug.WriteLine($"Processing {packagesToProcess} packages"); //Just to see if the right amount of packages are processed and in the right order
                while (packagesToProcess > 0 && priorityQueue.HasPackages())
                {
                    Package processedPackage = priorityQueue.Dequeue();
                    completedPackages.Add(processedPackage);
                    packagesToProcess--;
                }
            }

            //Dequeue remaining packages
            Debug.WriteLine($"Total amount of packages: {totalPackagesCreated}");
            Debug.WriteLine($"Packages left to process: {incomingPackages.Count - completedPackages.Count}");
            while (priorityQueue.HasPackages())
            {
                Package processedPackage = priorityQueue.Dequeue();
                completedPackages.Add(processedPackage);
            }
        }

    }
}