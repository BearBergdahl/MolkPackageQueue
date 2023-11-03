using System.Diagnostics;

namespace MolkPackageQueue
{
    internal class Program
    {
        // Config stuff
        private const int TotalPackagesToGenerate = 50; // Total number of packages to generate
        private const int PackageGenerationDelayMilliseconds = 1000; // Delay between generating packages
        private const int PackageSendingDelayMilliseconds = 1000; // Delay between sending packages
        private const int MinPackagesToGenerate = 1; // Minimum number of packages to generate at a time
        private const int MaxPackagesToGenerate = 10; // Maximum number of packages to generate at a time
        private const int MinPackagesToSend = 1; // Minimum number of packages to send at a time
        private const int MaxPackagesToSend = 5; // Maximum number of packages to send at a time

        private static readonly Random random = new Random(); // Random number generator

        static async Task Main(string[] args)
        {
            // Initialize the priority queue for packages
            var priorityQueue = new PriorityQueue<Package>();

            // Initialize lists for incoming and sent packages
            var incomingPackages = new List<Package>();
            var sentPackages = new List<Package>();

            Debug.WriteLine("Simulating package generation and queuing..."); // Debug output

            // Start generating and sending packages.. hopefully at the same time
            var generationTask = GenerateAndEnqueuePackagesAsync(priorityQueue, incomingPackages, TotalPackagesToGenerate, sentPackages);
            var sendingTask = SendPackagesAsync(priorityQueue, sentPackages);

            // Wait.. wait.. wait
            await Task.WhenAll(generationTask, sendingTask);

            Debug.WriteLine("Package generation and sending complete.");

            // Print the log of sent packages
            Console.WriteLine("Sent Packages with Timestamps:");

            foreach (var package in sentPackages)
            {
                Console.WriteLine($"Priority: {package.Priority}, PackageName: {package.Payload.PackageName}, Created: {package.CreatedTimestamp}, Sent: {package.SentTimestamp}");
            }

            // Print the log of incoming packages
            Console.WriteLine("Incoming Packages with Timestamps:");

            foreach (var package in incomingPackages)
            {
                Console.WriteLine($"Priority: {package.Priority}, PackageName: {package.Payload.PackageName}, Created: {package.CreatedTimestamp}");
            }
        }

        /// <summary>
        /// Generates and enqueues packages asynchronously.
        /// </summary>
        /// <param name="priorityQueue">The priority queue to enqueue packages into.</param>
        /// <param name="incomingPackages">The list to store incoming packages.</param>
        /// <param name="totalPackagesToGenerate">The total number of packages to generate.</param>
        /// <param name="sentPackages">The list to store sent packages.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task GenerateAndEnqueuePackagesAsync(PriorityQueue<Package> priorityQueue, List<Package> incomingPackages, int totalPackagesToGenerate, List<Package> sentPackages)
        {
            int packagesGenerated = 0;
            while (packagesGenerated < totalPackagesToGenerate)
            {
                // Generate a random number of packages to create and queue (between 1 and 10)
                int packagesToGenerate = random.Next(MinPackagesToGenerate, MaxPackagesToGenerate + 1);

                for (int i = 0; i < packagesToGenerate && packagesGenerated < totalPackagesToGenerate; i++)
                {
                    // Generate a random package
                    Package newPackage = RandomUtility.CreateRandomPackage();

                    // Enqueue the package in the priority queue
                    priorityQueue.Enqueue(newPackage);

                    // Add the package to the incoming packages list
                    incomingPackages.Add(newPackage);

                    // Increment the packages generated count
                    packagesGenerated++;

                    Debug.WriteLine($"Generated package - Priority: {newPackage.Priority}, PackageName: {newPackage.Payload.PackageName}");
                }

                Debug.WriteLine($"Generated {packagesToGenerate} packages.");

                // Delay to control the package generation rate
                await Task.Delay(PackageGenerationDelayMilliseconds);
            }
        }

        /// <summary>
        /// Sends packages asynchronously in chunks.
        /// </summary>
        /// <param name="priorityQueue">The priority queue to send packages from.</param>
        /// <param name="sentPackages">The list to store sent packages.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task SendPackagesAsync(
            PriorityQueue<Package> priorityQueue,
            List<Package> sentPackages)
        {
            while (sentPackages.Count < TotalPackagesToGenerate)
            {
                var packagesToSend = Math.Min(MaxPackagesToSend, TotalPackagesToGenerate - sentPackages.Count);

                if (packagesToSend > 0)
                {
                    var sentPackageTasks = new List<Task>();

                    for (int i = 0; i < packagesToSend; i++)
                    {
                        if (!priorityQueue.IsEmpty)
                        {
                            // Dequeue a package from the priority queue
                            Package sentPackage = priorityQueue.Dequeue();

                            // Set the sent timestamp
                            sentPackage.SentTimestamp = DateTime.Now;

                            // Add the sent package to the sent packages list
                            sentPackages.Add(sentPackage);

                            Debug.WriteLine($"Sent package - Priority: {sentPackage.Priority}, PackageName: {sentPackage.Payload.PackageName}, Created: {sentPackage.CreatedTimestamp}, Sent: {sentPackage.SentTimestamp}");

                            // Create a task to send the package
                            var sendPackageTask = SendPackageAsync(sentPackage);

                            // Add the task to the list
                            sentPackageTasks.Add(sendPackageTask);
                        }
                    }

                    // Wait for all sentPackageTasks to complete
                    await Task.WhenAll(sentPackageTasks);

                    Debug.WriteLine($"Sent {packagesToSend} packages.");
                }

                // Delay between sending chunks of packages.. a bit funky but it works.. kinda
                await Task.Delay(PackageSendingDelayMilliseconds);
            }
        }

        /// <summary>
        /// Sends a package asynchronously.
        /// </summary>
        /// <param name="package">The package to send.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task SendPackageAsync(Package package)
        {
            // Simulate sending the package asynchronously
            await Task.Delay(random.Next(500, 1000)); // Simulated delay between 0.5 to 1 seconds
            Debug.WriteLine($"Sent package - Priority: {package.Priority}, PackageName: {package.Payload.PackageName}, Created: {package.CreatedTimestamp}, Sent: {package.SentTimestamp}");
        }
    }
}