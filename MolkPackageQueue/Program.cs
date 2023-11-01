namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Package> incomingPackages = new List<Package>();
            List<Package> outgoingPackages = new List<Package>();
            List<Package> remainingPackages = new List<Package>();
            PriorityQueue<Package> priorityQueue = new PriorityQueue<Package>();    
            Random random = new Random();

            while (incomingPackages.Count < 50)
            {
                int packageToEnqueue = random.Next(1, 11);
                int packageToDequeue = random.Next(1, 6);

                for (int i = 0; i < packageToEnqueue; i++)
                {
                    Priority randomPriority = (Priority)random.Next(0, 3);
                    Package newPackage = PackageFactory.CreatePackage(randomPriority);
                    incomingPackages.Add(newPackage);
                    priorityQueue.Enqueue(newPackage);
                }

                for (int i = 0; i < packageToDequeue; i++)
                {
                    if (priorityQueue.queueHigh.Count == 0 && priorityQueue.queueMedium.Count == 0 && priorityQueue.queueLow.Count == 0) break;
                    Package removedPackage = priorityQueue.Dequeue();
                    outgoingPackages.Add(removedPackage);
                }
            }

          

            //LOGLIST FOR INCOMING PACKAGES

            Console.WriteLine(incomingPackages.Count + " - Incoming Packages:");
            foreach (var inPackage in incomingPackages)
            {
                Console.WriteLine($"Priority: {inPackage.Priority}, Payload: {inPackage.Payload.Content}");
            }


            //LOGLIST FOR OUTGOING PACKAGES

            Console.WriteLine("\n" + outgoingPackages.Count+ " - Outgoing Packages:");
            foreach (var outPackage in outgoingPackages)
            {
                Console.WriteLine($"Priority: {outPackage.Priority}, Payload: {outPackage.Payload.Content}");
                
            }


            //Dequeues the reminaining Packages

            while (priorityQueue.queueHigh.Count > 0 || priorityQueue.queueMedium.Count > 0 || priorityQueue.queueLow.Count > 0)
            {
                Package removedPackage = priorityQueue.Dequeue();
                outgoingPackages.Add(removedPackage);
                remainingPackages.Add(removedPackage);
            }


            //LOGGLIST FOR THE REMAINING PACKAGES
            Console.WriteLine("\n** OverTime incoming ** Remaining Packages:" +remainingPackages.Count);
            foreach (var package in remainingPackages)
            {
                Console.WriteLine($"Priority: {package.Priority}, Payload: {package.Payload.Content}");
            }


            Console.WriteLine("\nDequeing the remaining Packages..");


            Console.WriteLine("\nIncoming: " + incomingPackages.Count + " Outgoing: " +outgoingPackages.Count);

            int highPriorityCount = 0;
            int mediumPriorityCount = 0;
            int lowPriorityCount = 0;

            foreach (var package in incomingPackages)
            {
                switch (package.Priority)
                {
                    case Priority.Low:
                        {
                            lowPriorityCount++;
                            break;
                        }
                    case Priority.Medium:
                        {
                            mediumPriorityCount++;
                            break;
                        }
                    case Priority.High:
                        {
                            highPriorityCount++; 
                            break;
                        }
                }
            }

            Console.WriteLine("\nPackage Counts:");
            Console.WriteLine($"High Priority Count: {highPriorityCount}");
            Console.WriteLine($"Medium Priority Count: {mediumPriorityCount}");
            Console.WriteLine($"Low Priority Count: {lowPriorityCount}");


        }
    }
}
