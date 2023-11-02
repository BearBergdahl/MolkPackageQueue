namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");

            // Instantiate the MPS-PriorityQueue
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
            List<Package> inComming = new List<Package>();
            PriorityQueue priorityQueue = new PriorityQueue();
            RecivePackage recivePackage = new RecivePackage();

            inComming = recivePackage.ReciveIncomming();
            int index = 1;
            foreach (Package p in inComming)
            {
                Console.WriteLine($"{index}:{p.Priority}");
                index++;
            }


            // A way to sort incoming orders in a list by Priority!!!
            //List<Package> SortedList = inComming.OrderByDescending(o => o.Priority).ToList();

            //priorityQueue.ProcessingPackage(inComming);
           

        }
    }
}