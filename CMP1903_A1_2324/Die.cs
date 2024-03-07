using System;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Represents a single die that can be rolled to get a random value between 1 and 6.
    /// </summary>
    internal class Die
    {
        /// <summary>
        /// A static instance of the Random class to generate random numbers.
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Gets the current value of the die.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// The name of the die.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the Die class with a given name.
        /// </summary>
        /// <param name="name">The name of the die.</param>
        public Die(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Rolls the die and sets its value to a random number between 1 and 6.
        /// </summary>
        /// <param name="silent">A boolean value indicating whether to print the result to the console or not.</param>
        public void Roll(bool silent = false)
        {
            Value = random.Next(1, 7);
            if (!Program.isTestingMode) Console.WriteLine($"{name} rolled {Value}");
        }
    }
}
