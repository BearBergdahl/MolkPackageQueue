namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Implement MPS");
            // Instantiate the MPS-PriorityQueue
            PriorityQueue priorityQueue = new PriorityQueue();
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            List<Package> incomingPackages = new List<Package>();
            List<Package> completedPackages = new List<Package>();

            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
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
                for (int i = 0; i < packagesToCreate; i++)
                {
                    Package package = packageFactory.CreatePackage();
                    priorityQueue.Enqueue(package);
                    incomingPackages.Add(package);
                }
                totalPackagesCreated += packagesToCreate;

                //Dequeue 1-5 packages
                int packagesToProcess = randomizer.Next(1, 6);
                while (packagesToProcess > 0 && priorityQueue.HasPackages())
                {
                    Package processedPackage = priorityQueue.Dequeue();
                    completedPackages.Add(processedPackage);
                    packagesToProcess--;
                }
            }

            //Dequeue remaining packages
            while (priorityQueue.HasPackages())
            {
                Package processedPackage = priorityQueue.Dequeue();
                completedPackages.Add(processedPackage);
            }
        }

    }
}