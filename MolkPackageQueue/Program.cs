namespace MolkPackageQueue
{
    internal class Program
    {
        public static int numberOfOrderProcessed = 0;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Package> inComming = new List<Package>();
            List<Package> recived = new List<Package>();
            RecivePackage recivePackage = new RecivePackage();
            PriorityQueue priorityQueue = new PriorityQueue();

            Console.WriteLine();

            // Program loop
            while (numberOfOrderProcessed < 50)
            {
                if(recived.Count < 50) 
                {
                    inComming = recivePackage.ReciveIncomming(rnd.Next(1, 11));
                    recived.AddRange(inComming);
                    Console.WriteLine($"Sending {inComming.Count} packages for proccesing");
                    priorityQueue.ProcessingPackage(inComming);
                    priorityQueue.Dequeue();
                }
                else
                    priorityQueue.Dequeue();
               
            }

            Console.WriteLine();
            priorityQueue.DisplayAllOutgoing();
        }

        
    }
}