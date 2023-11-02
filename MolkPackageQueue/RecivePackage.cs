using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    internal class RecivePackage
    {
        PackageFactory factory = new PackageFactory();

        // Returns a list of packages with a random Count
        public List<Package> ReciveIncomming()
        {
            Random random = new Random();
            List<Package> incomming = new List<Package>();

            Console.WriteLine("---- Incoming Orders ----");
            
            while(incomming.Count < random.Next(30,100))
            {
                Package package = factory.CreatePackage();
                incomming.Add(package);
            }

            for (int i = 0; i < incomming.Count; i++)
                Console.WriteLine($"{i+1} : {incomming[i].Payload} : {incomming[i].Priority}");

            return incomming;
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
