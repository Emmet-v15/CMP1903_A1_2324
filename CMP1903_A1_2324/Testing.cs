using System;
using System.Diagnostics;
using System.Linq;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// A class that performs unit testing on the Die and Game classes.
    /// </summary>
    internal class Testing
    {
        /// <summary>
        /// Initializes a new instance of the Testing class and runs the tests.
        /// </summary>
        public Testing()
        {
            Program.isTestingMode = true;
            Console.WriteLine("Testing Die class...");
            TestDieClass();
            Console.WriteLine("Testing Game Class...");
            TestGameClass();
            Console.WriteLine("Testing succeeded.");
            Program.isTestingMode = false;
        }

        /// <summary>
        /// Tests the Die class by rolling a million dice and checking their values and distribution.
        /// </summary>
        private void TestDieClass()
        {
            int rollCount = 1_000_000;
            int[] rolls = new int[rollCount];

            // Create and roll a million dices.
            for (int i = 0; i < rollCount; i++)
            {
                Die die = new Die("Test die");
                die.Roll();
                rolls[i] = die.Value;
            }

            // Check if any of them are out of bounds.
            Debug.Assert(rolls.Max() <= 6, "Die rolled a value above 6.");
            Debug.Assert(rolls.Min() >= 0, "Die rolled a negative value.");

            // Check if the numbers are evenly distributed.
            Debug.Assert(IsEvenlyDistributed(rolls), "Die is not fair.");
        }

        /// <summary>
        /// Tests the Game class by creating a game with a million rolls and checking its sum and values.
        /// </summary>
        private void TestGameClass()
        {
            int rollCount = 1_000_000;
            Game game = new Game(rollCount); // Initialize the game with the amount of rolls we want.

            // Test if game behaves correctly.
            Debug.Assert(game.Sum == game.Values.Sum(), "Game did not sum die values correctly.");
            Debug.Assert(game.Values.Length == rollCount, "Game provided more rolls than was asked for.");
        }

        /// <summary>
        /// Checks if an array of integers is evenly distributed using the mean and standard deviation.
        /// </summary>
        /// <param name="array">The array of integers to check.</param>
        /// <returns>A boolean value indicating whether the array is evenly distributed or not.</returns>
        private bool IsEvenlyDistributed(int[] array)
        {
            double epsilon = 0.1; // margin of error.
            double mean = array.Average();
            double std = Math.Sqrt(array.Select(num => Math.Pow(num - mean, 2)).Average()); // How spread out the values are.
            bool is_even = true; // Assume even.
            if (Math.Abs(mean - 3.5) > epsilon || Math.Abs(std - 1.7078) > epsilon) is_even = false; // compare to our margin of error.
            return is_even;
        }
    }
}
