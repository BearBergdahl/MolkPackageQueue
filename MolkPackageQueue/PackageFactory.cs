using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        public Package CreatePackage()
        {
            int randomInt = new Random().Next(0,3);
            Priority prio = (Priority)Enum.ToObject(typeof(Priority), randomInt);
            return new Package(prio);
        }
    }
}
