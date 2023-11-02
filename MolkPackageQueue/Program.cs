namespace MolkPackageQueue
{
    internal class Program
    {
        public static int numberOfOrderProcessed = 0;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Package> inComming = new List<Package>();
            RecivePackage recivePackage = new RecivePackage();
            PriorityQueue priorityQueue = new PriorityQueue();

            // Creates a list of random number of packages with randomized priority and Payload
            inComming = recivePackage.ReciveIncomming();
            Console.WriteLine();

            // Sorts the incoming list by priority
            var sortedPackages = inComming.OrderByDescending(p => p.Priority).ToList();

            numberOfOrderProcessed = inComming.Count;

            // Program loop
            while (numberOfOrderProcessed > 0)
            {
                if(sortedPackages.Count > 0)
                {
                    //List<Package> sendToEnqueu = GetRandomItems(inComming, rnd.Next(1,11));
                    List<Package> sendToEnqueu = GetRandomNumberOfItems(sortedPackages);
                    Console.WriteLine($"Sending {sendToEnqueu.Count} packages for proccesing");
                    priorityQueue.ProcessingPackage(sendToEnqueu);
                    Task.Delay(1000).Wait();
                }
                else
                {
                    Console.WriteLine("No more Incoming orders....");
                    priorityQueue.Dequeue();
                    Task.Delay(1000).Wait();
                }

            }
            Console.WriteLine();
            priorityQueue.DisplayAllOutgoing();
        }

        // Picks random number of packages from list and returns a new list with packages => This is more fun
        public static List<Package> GetRandomItems(List<Package> packages, int count)
        {
            Random random = new Random();
            List<Package> selectedPackage = new List<Package>();

            while (selectedPackage.Count < count && packages.Count > 0)
            {
                int randomIndex = random.Next(packages.Count);
                Package selectedItem = packages[randomIndex];
                selectedPackage.Add(selectedItem);
                packages.Remove(selectedItem);
            }
            return selectedPackage;
        }

        // Picks random number of packages from list and returns a new list with packages => 
        public static List<Package> GetRandomNumberOfItems(List<Package> packages)
        {
            List<Package> selectedPackage = new List<Package>();
            Random random = new Random();
            int itemCount = random.Next(1, packages.Count + 1);

            for (int i = 0; i < itemCount && i < packages.Count; i++)
            {
                selectedPackage.Add(packages[i]);
                packages.RemoveAt(i);
            }

            return selectedPackage;
        }
    }
}