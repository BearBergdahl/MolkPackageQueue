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
            // Get all values of the Priority enum
            Array values = Enum.GetValues(typeof(Priority));

            // Select a random index
            int randomIndex = randomizer.Next(values.Length);

            // Get the Priority at the random index
            Priority randomPriority = (Priority)values.GetValue(randomIndex);

            // Use the random Priority to create a new Package
            return new Package(randomPriority);
        }
    }
}