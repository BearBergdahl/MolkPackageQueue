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

            Package package2 = new Package(priority: Priority.Medium);
            Package package1 = new Package(priority:Priority.Low);
            Package package3 = new Package(priority: Priority.High);
            Package package4 = new Package(priority: Priority.Low);


            inComming.Add(package1);
            inComming.Add(package2);
            inComming.Add(package3);
            inComming.Add(package4);

            // A way to sort incoming orders in a list by Priority!!!
            List<Package> SortedList = inComming.OrderByDescending(o => o.Priority).ToList();

            priorityQueue.ProcessingPackage(inComming);
           

        }
    }
}