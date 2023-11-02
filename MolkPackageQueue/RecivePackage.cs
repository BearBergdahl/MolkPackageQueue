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
    }
}
