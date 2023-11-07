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
            // Randomly select a priority level for the package
            Priority priority = (Priority)randomizer.Next(0, 3);
            return new Package(priority);
        }
    }
}
