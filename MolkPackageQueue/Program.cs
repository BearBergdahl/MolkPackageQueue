namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Package> incomingPackages = new List<Package>();
            List<Package> outgoingPackages = new List<Package>();
            PriorityQueue<Package> highPriorityQueue = new PriorityQueue<Package>();
            PriorityQueue<Package> mediumPriorityQueue = new PriorityQueue<Package>();
            PriorityQueue<Package> lowPriorityQueue = new PriorityQueue<Package>();
            PackageFactory packageFactory = new PackageFactory();
            Random random = new Random();
            int totalPackagesCreated = 0;

            Console.WriteLine("Program started.");

            do
            {
                // Randomly create 1-10 packages
                int packagesToCreate = random.Next(1, 11);
                for (int i = 0; i < packagesToCreate; i++)
                {
                    if (totalPackagesCreated >= 50) break;
                    Package newPackage = packageFactory.CreateRandomPackage();
                    incomingPackages.Add(newPackage);
                    switch (newPackage.Priority)
                    {
                        case Priority.High:
                            highPriorityQueue.Enqueue(Priority.High, newPackage);
                            break;
                        case Priority.Medium:
                            mediumPriorityQueue.Enqueue(Priority.Medium, newPackage);
                            break;
                        case Priority.Low:
                            lowPriorityQueue.Enqueue(Priority.Low, newPackage);
                            break;
                    }
                    totalPackagesCreated++;
                }

                // Randomly send 1-5 packages
                int packagesToSend = random.Next(1, 6);
                for (int i = 0; i < packagesToSend; i++)
                {
                    try
                    {
                        if (highPriorityQueue.Count > 0)
                        {
                            outgoingPackages.Add(highPriorityQueue.Dequeue());
                        }
                        else if (mediumPriorityQueue.Count > 0)
                        {
                            outgoingPackages.Add(mediumPriorityQueue.Dequeue());
                        }
                        else if (lowPriorityQueue.Count > 0)
                        {
                            outgoingPackages.Add(lowPriorityQueue.Dequeue());
                        }
                        else
                        {
                            Console.WriteLine("All priority queues are empty.");
                            break;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }

            } while (totalPackagesCreated < 50 || highPriorityQueue.Count > 0 || mediumPriorityQueue.Count > 0 || lowPriorityQueue.Count > 0);

            Console.WriteLine($"\nIncoming Packages ({incomingPackages.Count} packages):");
            foreach (var package in incomingPackages)
            {
                Console.WriteLine($"Package ID: {package.Payload.Content}, Priority: {package.Priority}");
            }

            Console.WriteLine($"\nOutgoing Packages ({outgoingPackages.Count} packages):");
            foreach (var package in outgoingPackages)
            {
                Console.WriteLine($"Package ID: {package.Payload.Content}, Priority: {package.Priority}");
            }

            Console.WriteLine("Program ended. Press any key to exit.");
            Console.ReadKey();
        }


    }
}