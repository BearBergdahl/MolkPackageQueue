using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        Random randomizer = new Random();
        
        public Package CreatePackage()
        {
            Priority priority = (Priority)randomizer.Next(0, 3); // Random priority from 0 to 2
            return new Package(priority);
        }
    }
}
