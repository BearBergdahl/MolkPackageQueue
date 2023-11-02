namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MPS-PriorityQueue
            // Create a function to queue and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
            Random rnd = new Random();
            List<Package> inComming = new List<Package>();
            RecivePackage recivePackage = new RecivePackage();
            PriorityQueue priorityQueue = new PriorityQueue();

            // Creates a list of 50 packages with randomized priority and Payload
            inComming = recivePackage.ReciveIncomming();
            Console.WriteLine(inComming.Count);


            List<Package> sendToEnqueu = GetRandomItems(inComming, rnd.Next(1,11));
            
            priorityQueue.ProcessingPackage(sendToEnqueu);
            Console.WriteLine(inComming.Count);

   




            // A way to sort incoming orders in a list by Priority!!!
            //List<Package> SortedList = inComming.OrderByDescending(o => o.Priority).ToList();

            //priorityQueue.ProcessingPackage(inComming);
           

        }
        public static List<Package> GetRandomItems(List<Package> packages, int count)
        {
            Random random = new Random();
            List<Package> selectedPackage = new List<Package>();

            while (selectedPackage.Count < count)
            {
                int randomIndex = random.Next(packages.Count);
                Package selectedItem = packages[randomIndex];
                selectedPackage.Add(selectedItem);
                packages.RemoveAt(randomIndex);
            }

            return selectedPackage;
        }
    }
}