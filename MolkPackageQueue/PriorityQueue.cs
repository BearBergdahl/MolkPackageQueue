using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        readonly Queue<Package> queueHigh = new Queue<Package>();
        readonly Queue<Package> queueMedium = new Queue<Package>();
        readonly Queue<Package> queueLow = new Queue<Package>();

        List<Package> incomingPackages = new List<Package>();
        List<Package> outgoingPackages = new List<Package>();

        public void PutPackageInQueue(Package package)
        {
            if (package.Priority == Priority.High)
            {               
                queueHigh.Enqueue(package);
                incomingPackages.Add(package);
            }
            else if (package.Priority == Priority.Medium)
            {
                queueMedium.Enqueue(package);
                incomingPackages.Add(package);
            }
            else if (package.Priority == Priority.Low)
            {
                queueLow.Enqueue(package);
                incomingPackages.Add(package);
            }


           //foreach (Package p in incomingPackages) 
           // {
           //     if (package.Priority == Priority.Low)
           //     {
           //         Console.ForegroundColor = ConsoleColor.Red;
           //         Console.Write("█ ");
           //         Console.Beep(700,100);
           //     }
           //     else if(package.Priority == Priority.Medium) 
           //     {
           //         Console.ForegroundColor = ConsoleColor.Yellow;
           //         Console.Write("█ ");
           //         Console.Beep(800, 100);
           //     }
           //     else if (package.Priority == Priority.Medium)
           //     {
           //         Console.ForegroundColor = ConsoleColor.Green;
           //         Console.Write("█ ");
           //         Console.Beep(1000, 100);
           //     }
           //     Console.ResetColor();
           //     Console.Write("| End");
           // }
            
        }
        public void RemovePackageFromQueue()
        {
            if (queueHigh.Count > 0)
            {
                Package packageHigh = queueHigh.Dequeue();
                //Console.Write(packageHigh.Payload.packageName + ", ");
                outgoingPackages.Add(packageHigh);
            }
            else if (queueMedium.Count > 0)
            {
                Package packageMedium = queueMedium.Dequeue();
                //Console.Write(packageMedium.Payload.packageName + ", ");
                outgoingPackages.Add(packageMedium);
            }
            else if (queueLow.Count > 0)
            {
                Package packageLow = queueLow.Dequeue();
                //Console.Write(packageLow.Payload.packageName + ", ");
                outgoingPackages.Add(packageLow);
            }
        }
    }
}
