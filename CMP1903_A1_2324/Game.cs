using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Represents a game of rolling dice and summing their values.
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// Gets the sum of the dice values.
        /// </summary>
        public int Sum { get; private set; }
        /// <summary>
        /// Gets the array of the dice values.
        /// </summary>
        public int[] Values { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class with a specified number of dice.
        /// </summary>
        /// <param name="rollCount">The number of dice to roll. The default is 3.</param>
        public Game(int rollCount = 3)
        {


            Die[] dice = new Die[rollCount]; // Array to hold all the dice.
            Values = new int[rollCount]; // Array to hold all values of the dice.

            for (int i = 0; i < rollCount; i++)
            {
                dice[i] = new Die("Die " + (i + 1)); // Instantiate dices
            }

            for (int j = 0; j < rollCount; j++)
            {
                dice[j].Roll(); // Roll all dice once.
            }

            Values = dice.Select(die => die.Value).ToArray(); // Extract value property of the dice.
            Sum = Values.Sum();

            if (!Program.isTestingMode) // Do not log to console if game is in testing mode.
            {
                Console.WriteLine("Total Roll: " + Sum);
            }
        }
    }
}
