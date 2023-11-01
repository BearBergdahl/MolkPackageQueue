namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Implement MPS");
            // Instantiate the MPS-PriorityQueue
            PriorityQueue priorityQueue = new PriorityQueue();
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            List<Package> incomingPackages = new List<Package>();
            List<Package> completedPackages = new List<Package>();

            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
        }
    }
}