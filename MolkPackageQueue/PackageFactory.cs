using System;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        private Random randomizer = new Random();

        public Package CreatePackage()
        {
            Priority priority = (Priority)randomizer.Next(0, 3);
            return new Package(priority);
        }
    }
}
