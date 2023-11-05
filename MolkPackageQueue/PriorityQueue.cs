using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        public List<Package> SentPackagesList = new List<Package>();
        public Queue<Package> queueHigh = new Queue<Package>();
        public Queue<Package> queueMedium = new Queue<Package>();
        public Queue<Package> queueLow = new Queue<Package>();
        PackageFactory packageFactory = new PackageFactory();

        public void Enqueue(Package package)
        {
            if (package.Priority == Priority.High)
            {
                queueHigh.Enqueue(package);
                Console.WriteLine($"{package.Payload.PackageName} added to priority high");
            }
            if (package.Priority == Priority.Medium)
            {
                queueMedium.Enqueue(package);
                Console.WriteLine($"{package.Payload.PackageName} added to priority medium");
            }
            if (package.Priority == Priority.Low)
            {
                queueLow.Enqueue(package);
                Console.WriteLine($"{package.Payload.PackageName} added to priority low");
            }
        }
        public void Dequeue(int send)
        {
            Package package = new Package();
            
            for (int i = 1; i <= send; i++) {
                if (queueHigh.Count == 0 && queueMedium.Count == 0)
                {
                    if (queueLow.Count > 0)
                    {
                        package = queueLow.Dequeue();
                        Console.WriteLine($"{package.Payload.PackageName} {package.Priority} sended");
                    }
                }
                if (queueHigh.Count == 0 && queueMedium.Count > 0)
                {
                    package = queueMedium.Dequeue();
                    Console.WriteLine($"{package.Payload.PackageName} {package.Priority} sended");
                }
                if (queueHigh.Count > 0)
                {
                    package = queueHigh.Dequeue();
                    Console.WriteLine($"{package.Payload.PackageName} {package.Priority} sended");
                }
                SentPackagesList.Add(package);
            }
        }
        public void CreatingAndSending()
        {
            Random random = new Random();
            int created = 0;

            while (created < 50)
            {
                Console.WriteLine("");
                Console.WriteLine($"--- {created} created ---");
                Console.WriteLine("");
                int creadPackage = random.Next(1, 11);
                Console.WriteLine($"{creadPackage} packages creates");
                Console.WriteLine("");
                for (int i = 1; i <= creadPackage; i++)
                {
                    Enqueue(packageFactory.CreatePackage());
                }
                created += creadPackage;
                int sendPackage = random.Next(1, 6);
                Console.WriteLine("");
                Console.WriteLine($"{sendPackage} sends");
                Console.WriteLine("");
                Dequeue(sendPackage);
                Thread.Sleep(1000);
            }
            while (queueHigh.Count > 0 || queueLow.Count > 0 || queueMedium.Count > 0)
            {
                int sendPackage = random.Next(1, 6);
                Console.WriteLine("");
                Console.WriteLine($"{sendPackage} sends");
                Console.WriteLine("");
                Dequeue(sendPackage);
                Thread.Sleep(1000);
            }
        }
        public void HighListPrint()
        {
            Console.WriteLine("");
            Console.WriteLine("High priority list");
            Console.WriteLine("");
            foreach (var list in queueHigh)
            {
                Console.WriteLine(list.Payload.PackageName);
            }
        }
        public void MediumListPrint()
        {
            Console.WriteLine("");
            Console.WriteLine("Medium priority list");
            Console.WriteLine("");
            foreach (var list in queueMedium)
            {
                Console.WriteLine(list.Payload.PackageName);
            }
        }
        public void LowListPrint()
        {
            Console.WriteLine("");
            Console.WriteLine("Low priority list");
            Console.WriteLine("");
            foreach (var list in queueLow)
            {
                Console.WriteLine(list.Payload.PackageName);
            }
        }
        public void PrintPriorityLists()
        {
            HighListPrint();
            MediumListPrint();
            LowListPrint();
        }
        public void PrintHistory()
        {
            Console.WriteLine("");
            Console.WriteLine("Package sending history list:");
            Console.WriteLine("");

            if (SentPackagesList != null)
            {
                foreach (var listlog in SentPackagesList)
                {
                    Console.WriteLine($"{listlog.Payload.PackageName} {listlog.Priority}");
                }
            }
            else
            {
                foreach (var listlog in SentPackagesList)
                {
                    Console.WriteLine($"{listlog.Payload.PackageName} {listlog.Priority}");
                }
            }
        }
    }
}
