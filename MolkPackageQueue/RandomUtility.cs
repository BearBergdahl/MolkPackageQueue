namespace MolkPackageQueue
{
    /// <summary>
    /// A utility class for generating random packages and priorities.
    /// </summary>
    public static class RandomUtility
    {
        private static readonly Random random = new Random();
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö";

        /// <summary>
        /// Generates a random package with a random priority.
        /// </summary>
        /// <returns>A randomly generated package.</returns>
        public static Package CreateRandomPackage()
        {
            Priority randomPriority = GenerateRandomPriority();
            return new Package(randomPriority);
        }

        /// <summary>
        /// Generates a random name of the specified length.
        /// </summary>
        /// <param name="length">The length of the random name to generate.</param>
        /// <returns>A random name of the specified length.</returns>
        public static string GenerateRandomName(int length)
        {
            char[] name = new char[length];
            for (int i = 0; i < length; i++)
            {
                name[i] = letters[random.Next(letters.Length)];
            }
            return new string(name);
        }

        /// <summary>
        /// Generates a random priority (High, Medium, or Low) with customizable chances.
        /// </summary>
        /// <returns>A randomly generated priority.</returns>
        public static Priority GenerateRandomPriority()
        {
            // You can adjust the chances here by changing the ranges
            int randomNumber = random.Next(1, 101); // Generates a random number between 1 and 100

            if (randomNumber <= 33) // 33% chance for High priority
                return Priority.High;
            else if (randomNumber <= 66) // 33% chance for Medium priority
                return Priority.Medium;
            else // 34% chance for Low priority
                return Priority.Low;
        }
    }
}