using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    public class Payload 
    {
        string packageName = string.Empty; 
        public string Content { get; set; }
        public Payload()
        {
            Content = GenerateRandomText();
        }

        private string GenerateRandomText()
        {
            const string words = "sport,medicine,clothes,shoes,protein,food,office"; 
            var random = new Random();
            string[] wordArray = words.Split(',');
            return wordArray[random.Next(wordArray.Length)];
        }
    }
}
