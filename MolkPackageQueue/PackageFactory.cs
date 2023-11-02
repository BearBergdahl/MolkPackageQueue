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
            // Use randomizer to send in a prio-enum
            Priority prio = (Priority)randomizer.Next(0,3);
            return new Package(prio);
        }
    }
}
