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
        public static Package CreatePackage(Priority prio)
        {
            return new Package(prio);
        }
    }
}
