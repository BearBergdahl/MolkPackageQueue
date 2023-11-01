using System;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        Random randomizer = new Random();

        public Package CreatePackage()
        {
            Priority prio = (Priority)randomizer.Next(0, 3);
            return new Package(prio);
        }
    }
}
