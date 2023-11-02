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
                    List<Package> sendToEnqueu = RecivePackage.GetRandomItems(sortedPackages, rnd.Next(1,11));
                    //List<Package> sendToEnqueu = RecivePackage.GetRandomNumberOfItems(sortedPackages);
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
        
    }
}