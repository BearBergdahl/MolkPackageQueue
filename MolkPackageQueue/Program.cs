namespace MolkPackageQueue
{
    internal class Program
    {
        public static bool gotAllOrders = false;
        public static bool clearAllQueus = false;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Package> inComming = new List<Package>();
            List<Package> recived = new List<Package>();
            RecivePackage recivePackage = new RecivePackage();
            PriorityQueue priorityQueue = new PriorityQueue();

            Console.WriteLine();

            // Program loop
            while (!clearAllQueus)
            {
                if(recived.Count < 50) 
                {
                    inComming = recivePackage.ReciveIncomming(rnd.Next(1, 11));
                    recived.AddRange(inComming);
                    Console.WriteLine($"Sending {inComming.Count} packages for proccesing");
                    priorityQueue.ProcessingPackage(inComming);
                    priorityQueue.Dequeue(rnd.Next(1,6));
                }
                else
                {
                    gotAllOrders = true;
                    priorityQueue.Dequeue(rnd.Next(1, 6));
                }
            }
            Console.WriteLine(recived.Count) ;
            Console.WriteLine();
            priorityQueue.DisplayAllOutgoing();
        }

        
    }
}