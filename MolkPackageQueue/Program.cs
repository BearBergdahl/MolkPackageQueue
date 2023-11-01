namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");

            PackageFactory packageFactory = new PackageFactory();
            PriorityQueue priorityQueue = new PriorityQueue();

            int packagesProduced = 0;
            int packagesDelivered = 0;
            bool continueProduction = true;
            bool continueDelivery = true;
            while (continueProduction || continueDelivery)
            {
                if (packagesProduced < 50)
                {
                    int batchSize = new Random().Next(1, 10);
                    for (int i = 0; i < batchSize; i++)
                    {
                        Package package = packageFactory.CreatePackage();
                        packagesProduced++;
                        priorityQueue.Enqueue(package);
                    }
                }
                else
                {
                    continueProduction = false;
                }

                int deliveryBatch = new Random().Next(1,5);
                for (int i = 0; i < deliveryBatch; i++)
                {
                    priorityQueue.Dequeue();
                    packagesDelivered++;
                }
                if (packagesDelivered == packagesProduced && !continueProduction)
                {
                    continueDelivery = false;
                }
            }

            Console.WriteLine("packagesCreatedLog:");
            foreach (Package package in priorityQueue.packagesCreatedLog)
            {
                Console.WriteLine(package);
            }
            Console.WriteLine("packagesHandledLog:");
            foreach (Package package in priorityQueue.packagesHandledLog)
            {
                Console.WriteLine(package);
            }

        }
    }
}