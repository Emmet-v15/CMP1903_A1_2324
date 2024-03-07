using System;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// The main class of the program that runs the tests and the game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// A static boolean field that indicates whether the program is in testing mode or not.
        /// </summary>
        public static bool isTestingMode;
        /// <summary>
        /// The entry point of the program that creates and runs the Testing and Game objects.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the program.</param>
        static void Main(string[] args)
        {
            _ = new Testing();
            _ = new Game();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
