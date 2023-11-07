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
            int randomizer = new Random().Next(0,3);
            Priority prio = Priority.Low;
            if (randomizer == 0)
            {
                prio = Priority.Low;              
            }
            else if (randomizer == 1)
            {
                prio = Priority.Medium;
            }
            else if (randomizer == 2)
            {
                prio = Priority.High;
            }
            //use randomizer to send in a prio-enum
            return new Package(prio);
        }
    }
}
