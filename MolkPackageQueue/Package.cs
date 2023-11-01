namespace MolkPackageQueue
{
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    public class Payload
    {
        public string Empty { get; set; } = "packet";
    }

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
}
