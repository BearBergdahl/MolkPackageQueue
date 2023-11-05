using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        public List<Package> SentPackagesList2 = new List<Package>();
        public Package CreatePackage()
        {
            Priority prio = new Priority();
            Random randomizer = new Random();
            Array enums = Enum.GetValues(typeof(Priority));
            prio = (Priority)randomizer.Next(0, enums.Length);
            return new Package(prio);
        }
    }
}
