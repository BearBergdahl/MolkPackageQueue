using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{

    //Method for creating a package with a priority.
    public class PackageFactory
    {
        Random randomizer = new Random();

        public Package CreatePackage(Priority priority)
        {
            return new Package(priority);
        }

        public Package CreateRandomPackage()
        {
            Priority randomPriority = (Priority)randomizer.Next(0, 3);
            return CreatePackage(randomPriority);
        }
    }
}
