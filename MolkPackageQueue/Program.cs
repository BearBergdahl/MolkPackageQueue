namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");             
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
            List<Package> incomingPackages = new List<Package>(); // Don´t forget the logging lists

            List<Package> outgoingPackages = new List<Package>();
            PriorityQueue queue = new PriorityQueue(); // Instantiate the MPS-PriorityQueue
            Random random = new Random();

            while (incomingPackages.Count < 10) // Create a function to queue and dequeue packages according to the rules. 
            {
                int packagesToAdd = random.Next(1, 11); 
                int packagesToRemove = random.Next(1, 6); 

                for (int i = 0; i < packagesToAdd; i++)
                {
                    Priority priority = (Priority)random.Next(3);
                    Package package = new Package(priority);
                    incomingPackages.Add(package);
                    queue.Enqueue(package);
                }

                for (int i = 0; i < packagesToRemove; i++)
                {
                    Package package = queue.Dequeue();
                    if (package != null)
                    {
                        outgoingPackages.Add(package);
                    }
                }
            }

            
            Console.WriteLine("Inkommande paket:"); // Print log for packages created in order of creation, with payload packageName and package priority
            foreach (var package in incomingPackages)
            {
                Console.WriteLine($"Prioritet: {package.Priority}, Innehåll: {package.Payload.Content}");
            }

            Console.WriteLine("Utgående paket:"); // Print log for packages handled (dequeue and add to logg), same content as above.
            foreach (var package in outgoingPackages)
            {
                Console.WriteLine($"Prioritet: {package.Priority}, Innehåll: {package.Payload.Content}");
            }
        }
    }
}