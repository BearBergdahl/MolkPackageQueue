using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        Random randomizer = new Random();
        public Package CreatePackage()
        {
            var randomPrio = (Priority)randomizer.Next(0, 3);
            //use randomizer to send in a prio-enum
            return new Package(randomPrio);
        }
    }
}
