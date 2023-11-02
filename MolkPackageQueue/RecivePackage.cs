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

        // Plays the Reciver of the code that fetch orders from custommers Online
        public List<Package> ReciveIncomming()
        {
            List<Package> incomming = new List<Package>();
            
            while(incomming.Count < 50)
            {
                Package package = factory.CreatePackage();
                incomming.Add(package);
            }
            return incomming;
        }
    }
}
